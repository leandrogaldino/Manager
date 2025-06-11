Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmCompressorSellableElapsedDay
    Private _CompressorForm As FrmCompressor
    Private _Compressor As Compressor
    Private _ElapsedDaySellable As CompressorSellable
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
    Public Sub New(Compressor As Compressor, PartElapsedDay As CompressorSellable, CompressorForm As FrmCompressor)
        InitializeComponent()
        _Compressor = Compressor
        _ElapsedDaySellable = PartElapsedDay
        _CompressorForm = CompressorForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _CompressorForm.DgvCompressorSellableElapsedDay
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_ElapsedDaySellable.IsSaved, _CompressorForm.DgvCompressorSellableElapsedDay.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _ElapsedDaySellable.Creation
        ClearQbxSellable()
        SetUpQbxSellableForProduct()
        If _ElapsedDaySellable.Sellable Is Nothing Then RbtProduct.Checked = True
        If _ElapsedDaySellable.Sellable IsNot Nothing AndAlso _ElapsedDaySellable.SellableType = SellableType.Product Then RbtProduct.Checked = True
        If _ElapsedDaySellable.Sellable IsNot Nothing AndAlso _ElapsedDaySellable.SellableType = SellableType.Service Then RbtService.Checked = True
        If _ElapsedDaySellable.Sellable IsNot Nothing AndAlso _ElapsedDaySellable.SellableID > 0 Then QbxSellable.Freeze(_ElapsedDaySellable.SellableID)
        DbxQuantity.Text = _ElapsedDaySellable.Quantity
        If Not _ElapsedDaySellable.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        QbxSellable.Select()
        _Loading = False
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
        If _CompressorForm.DgvCompressorSellableElapsedDay.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ElapsedDaySellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _CompressorForm.DgvCompressorSellableElapsedDay.SelectedRows(0).Cells("Guid").Value)
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
        Dim Frm As New FrmLog(Routine.CompressorSellableElapsedDay, _ElapsedDaySellable.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _ElapsedDaySellable.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _ElapsedDaySellable.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles QbxSellable.TextChanged,
                                                                         DbxQuantity.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub

    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(QbxSellable.Text) Then
            EprValidation.SetError(RbtService, "Campo Obrigatório.")
            EprValidation.SetIconAlignment(RbtService, ErrorIconAlignment.MiddleRight)
            QbxSellable.Select()
            Return False
        ElseIf RbtProduct.Checked And Not QbxSellable.IsFreezed Then
            EprValidation.SetError(RbtService, "Produto não encontrado.")
            EprValidation.SetIconAlignment(RbtService, ErrorIconAlignment.MiddleRight)
            QbxSellable.Select()
            Return False
        ElseIf RbtService.Checked And Not QbxSellable.IsFreezed Then
            EprValidation.SetError(RbtService, "Serviço não encontrado.")
            EprValidation.SetIconAlignment(RbtService, ErrorIconAlignment.MiddleRight)
            QbxSellable.Select()
            Return False
        ElseIf DbxQuantity.DecimalValue <= 0 Then
            EprValidation.SetError(LblQuantity, "A quantidade deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblQuantity, ErrorIconAlignment.MiddleRight)
            DbxQuantity.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If HasDuplicatedItem() Then Return False
            If _ElapsedDaySellable.IsSaved Then
                _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Quantity = DbxQuantity.DecimalValue
                If RbtProduct.Checked Then
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Sellable = New Lazy(Of Sellable)(Function() New Product().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Sellable.Value
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).SellableID = Sellable.ID
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Name = Sellable.Name
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Code = CType(Sellable, Product).ProviderCodes.FirstOrNew(Function(x) x.IsMainProvider = True).Code
                Else
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Sellable = New Lazy(Of Sellable)(Function() New Service().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Sellable.Value
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).SellableID = Sellable.ID
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Name = Sellable.Name
                    _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid).Code = String.Empty
                End If

            Else
                _ElapsedDaySellable = New CompressorSellable(CompressorSellableControlType.ElapsedDay) With {
                    .Quantity = DbxQuantity.DecimalValue
                }
                If RbtProduct.Checked Then
                    _ElapsedDaySellable.Sellable = New Lazy(Of Sellable)(Function() New Product().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _ElapsedDaySellable.Sellable.Value
                    _ElapsedDaySellable.SellableID = Sellable.ID
                    _ElapsedDaySellable.Name = Sellable.Name
                    _ElapsedDaySellable.Code = CType(Sellable, Product).ProviderCodes.FirstOrNew(Function(x) x.IsMainProvider = True).Code
                    _ElapsedDaySellable.Quantity = DbxQuantity.DecimalValue
                Else
                    _ElapsedDaySellable.Sellable = New Lazy(Of Sellable)(Function() New Service().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _ElapsedDaySellable.Sellable.Value
                    _ElapsedDaySellable.SellableID = Sellable.ID
                    _ElapsedDaySellable.Name = Sellable.Name
                    _ElapsedDaySellable.Code = String.Empty
                    _ElapsedDaySellable.Quantity = DbxQuantity.DecimalValue
                End If
                _ElapsedDaySellable.SetIsSaved(True)
                _Compressor.ElapsedDaySellables.Add(_ElapsedDaySellable)
            End If
            _CompressorForm.DgvCompressorSellableElapsedDay.Fill(_Compressor.ElapsedDaySellables)
            _CompressorForm.DgvCompressorSellableElapsedDayLayout.Load()
            BtnSave.Enabled = False
            If Not _ElapsedDaySellable.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _CompressorForm.DgvCompressorSellableElapsedDay.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _ElapsedDaySellable.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _CompressorForm.DgvCompressorSellableElapsedDay.SelectedRows(0).Cells("Order").Value
            _CompressorForm.EprValidation.Clear()
            _CompressorForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function HasDuplicatedItem() As Boolean
        Dim TargetItems As List(Of CompressorSellable)
        If RbtProduct.Checked Then
            TargetItems = _Compressor.ElapsedDaySellables.Where(Function(x) Not x.SellableID.Equals(_ElapsedDaySellable.SellableID) AndAlso x.Product IsNot Nothing AndAlso x.SellableID.Equals(QbxSellable.FreezedPrimaryKey)).ToList
        Else
            TargetItems = _Compressor.ElapsedDaySellables.Where(Function(x) Not x.SellableID.Equals(_ElapsedDaySellable.SellableID) AndAlso x.Service IsNot Nothing AndAlso x.SellableID.Equals(QbxSellable.FreezedPrimaryKey)).ToList
        End If
        If TargetItems IsNot Nothing AndAlso TargetItems.Count > 0 Then
            If RbtProduct.Checked Then
                CMessageBox.Show("Esse produto já foi incluido na tabela.", CMessageBoxType.Information)
            Else
                CMessageBox.Show("Esse serviço já foi incluido na tabela.", CMessageBoxType.Information)
            End If
            Return True
        End If
        Return False
    End Function
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxItem_Enter(sender As Object, e As EventArgs) Handles QbxSellable.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxSellable.IsFreezed And _User.CanWrite(Routine.Product)
        BtnNew.Visible = _User.CanWrite(Routine.Product)
        BtnFilter.Visible = _User.CanAccess(Routine.Product)
    End Sub
    Private Sub QbxItem_Leave(sender As Object, e As EventArgs) Handles QbxSellable.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxItem_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxSellable.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxSellable.IsFreezed And _User.CanWrite(Routine.Product)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Product As Product
        Dim Form As FrmProduct
        Product = New Product
        Form = New FrmProduct(Product)
        Form.ShowDialog()
        EprValidation.Clear()
        If Product.ID > 0 Then
            QbxSellable.Freeze(Product.ID)
        End If
        QbxSellable.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Form As New FrmProduct(New Product().Load(QbxSellable.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxSellable.Freeze(QbxSellable.FreezedPrimaryKey)
        QbxSellable.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New ProductQueriedBoxFilter(), QbxSellable)
        FilterForm.Text = "Filtro de Produtos"
        FilterForm.ShowDialog()
        QbxSellable.Select()
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _ElapsedDaySellable = New CompressorSellable(CompressorSellableControlType.ElapsedDay)
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CompressorForm.DgvCompressorSellableElapsedDay.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ElapsedDaySellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _CompressorForm.DgvCompressorSellableElapsedDay.SelectedRows(0).Cells("Guid").Value)
                _Compressor.ElapsedDaySellables.Remove(_ElapsedDaySellable)
                _CompressorForm.DgvCompressorSellableElapsedDay.Fill(_Compressor.ElapsedDaySellables)
                _CompressorForm.DgvCompressorSellableElapsedDayLayout.Load()
                _Deleting = True
                Dispose()
                _CompressorForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub RbtPart_CheckedChanged(sender As Object, e As EventArgs) Handles RbtProduct.CheckedChanged
        ClearQbxSellable()
        If RbtProduct.Checked Then
            SetUpQbxSellableForProduct()
        Else
            SetUpQbxSellableForService()
        End If
    End Sub
    Private Sub ClearQbxSellable()
        QbxSellable.Unfreeze()
        QbxSellable.MainTableName = Nothing
        QbxSellable.DisplayFieldName = Nothing
        QbxSellable.DisplayFieldAlias = Nothing
        QbxSellable.MainReturnFieldName = Nothing
        QbxSellable.DisplayMainFieldName = Nothing
        QbxSellable.DisplayTableName = Nothing
        QbxSellable.Parameters.Clear()
        QbxSellable.Conditions.Clear()
        QbxSellable.OtherFields.Clear()
        QbxSellable.Relations.Clear()
    End Sub
    Private Sub SetUpQbxSellableForService()
        QbxSellable.MainTableName = "service"
        QbxSellable.MainReturnFieldName = "id"
        QbxSellable.DisplayTableName = "service"
        QbxSellable.DisplayFieldName = "name"
        QbxSellable.DisplayFieldAlias = "Serviço"
        QbxSellable.DisplayFieldAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.Fill
        QbxSellable.DisplayMainFieldName = "id"
        QbxSellable.Conditions.Add(New QueriedBox.Condition() With {
            .FieldName = "statusid",
            .[Operator] = "=",
            .TableNameOrAlias = "service",
            .Value = "@statusid"
        })
        QbxSellable.Parameters.Add(New QueriedBox.Parameter() With {
            .ParameterName = "@statusid",
            .ParameterValue = 0
        })
    End Sub
    Private Sub SetUpQbxSellableForProduct()
        QbxSellable.MainTableName = "product"
        QbxSellable.DisplayFieldName = "code"
        QbxSellable.DisplayFieldAlias = "Código"
        QbxSellable.DisplayFieldAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.AllCells
        QbxSellable.MainReturnFieldName = "id"
        QbxSellable.DisplayMainFieldName = "id"
        QbxSellable.DisplayTableName = "productprovidercode"
        QbxSellable.Relations.Add(New QueriedBox.Relation() With {
            .[Operator] = "=",
            .RelateFieldName = "productid",
            .RelateTableName = "productprovidercode",
            .RelationType = "LEFT",
            .WithFieldName = "id",
            .WithTableName = "product",
            .Conditions = New ObjectModel.Collection(Of QueriedBox.Condition) From {
            New QueriedBox.Condition() With {
                .FieldName = "ismainprovider",
                .[Operator] = "=",
                .TableNameOrAlias = "productprovidercode",
                .Value = "@ismainprovider"
                }
            }
        })
        QbxSellable.Parameters.Add(New QueriedBox.Parameter() With {
            .ParameterName = "@statusid",
            .ParameterValue = 0
        })
        QbxSellable.Parameters.Add(New QueriedBox.Parameter() With {
            .ParameterName = "@ismainprovider",
            .ParameterValue = 1
        })
        QbxSellable.OtherFields.Add(New QueriedBox.OtherField() With {
            .Freeze = True,
            .DisplayFieldAlias = "Peça",
            .DisplayFieldName = "name",
            .DisplayMainFieldName = "id",
            .DisplayTableName = "product",
            .DisplayFieldAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.Fill
        })
        QbxSellable.Conditions.Add(New QueriedBox.Condition() With {
            .FieldName = "statusid",
            .[Operator] = "=",
            .TableNameOrAlias = "product",
            .Value = "@statusid"
        })
    End Sub
End Class