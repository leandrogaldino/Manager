Imports ControlLibrary
Imports ControlLibrary.Extensions

Public Class FrmPriceTableSellable
    Private _PriceTableForm As FrmPriceTable
    Private _PriceTable As PriceTable
    Private _PriceTableItem As PriceTableSellable
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
    Public Sub New(PriceTable As PriceTable, PriceTableItem As PriceTableSellable, PriceTableForm As FrmPriceTable)
        InitializeComponent()
        _PriceTable = PriceTable
        _PriceTableItem = PriceTableItem
        _PriceTableForm = PriceTableForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _PriceTableForm.DgvPriceTableSellable
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_PriceTableItem.IsSaved, _PriceTableForm.DgvPriceTableSellable.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _PriceTableItem.Creation
        ClearQbxSellable()
        SetUpQbxSellableForProduct()
        If _PriceTableItem.Sellable Is Nothing Then RbtProduct.Checked = True
        If _PriceTableItem.Sellable IsNot Nothing AndAlso _PriceTableItem. SellableType = SellableType.Product Then RbtProduct.Checked = True
        If _PriceTableItem.Sellable IsNot Nothing AndAlso _PriceTableItem.SellableType = SellableType.Service Then RbtService.Checked = True
        If _PriceTableItem.Sellable IsNot Nothing AndAlso _PriceTableItem.SellableID > 0 Then QbxSellable.Freeze(_PriceTableItem.SellableID)
        DbxPrice.Text = _PriceTableItem.Price
        If Not _PriceTableItem.IsSaved Then
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
        If _PriceTableForm.DgvPriceTableSellable.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _PriceTableItem = _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableForm.DgvPriceTableSellable.SelectedRows(0).Cells("Guid").Value)
            LoadForm()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _Deleting AndAlso BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then e.Cancel = True
            End If
        End If
        _Deleting = False
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
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.PriceTableSellable, _PriceTableItem.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub QbxSellable_TextChanged(sender As Object, e As EventArgs) Handles QbxSellable.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub DbxPrice_TextChanged(sender As Object, e As EventArgs) Handles DbxPrice.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxSellable.Text) Then
            EprValidation.SetError(RbtService, "Campo obrigatório.")
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
        ElseIf DbxPrice.DecimalValue < 0 Then
            EprValidation.SetError(LblPrice, "O Preço deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblPrice, ErrorIconAlignment.MiddleRight)
            DbxPrice.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If HasDuplicatedItem() Then Return False
            If _PriceTableItem.IsSaved Then
                _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Price = DbxPrice.DecimalValue
                If RbtProduct.Checked Then
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Sellable = New Lazy(Of Sellable)(Function() New Product().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Sellable.Value
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).SellableID = Sellable.ID
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Name = Sellable.Name
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Code = CType(Sellable, Product).ProviderCodes.FirstOrNew(Function(x) x.IsMainProvider = True).Code
                Else
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Sellable = New Lazy(Of Sellable)(Function() New Service().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Sellable.Value
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).SellableID = Sellable.ID
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Name = Sellable.Name
                    _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableItem.Guid).Code = String.Empty
                End If

            Else
                _PriceTableItem = New PriceTableSellable With {
                    .Price = DbxPrice.DecimalValue
                }
                If RbtProduct.Checked Then
                    _PriceTableItem.Sellable = New Lazy(Of Sellable)(Function() New Product().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _PriceTableItem.Sellable.Value
                    _PriceTableItem.SellableID = Sellable.ID
                    _PriceTableItem.Name = Sellable.Name
                    _PriceTableItem.Code = CType(Sellable, Product).ProviderCodes.FirstOrNew(Function(x) x.IsMainProvider = True).Code
                    _PriceTableItem.Price = DbxPrice.DecimalValue
                Else
                    _PriceTableItem.Sellable = New Lazy(Of Sellable)(Function() New Service().Load(QbxSellable.FreezedPrimaryKey, False))
                    Dim Sellable As Sellable = _PriceTableItem.Sellable.Value
                    _PriceTableItem.SellableID = Sellable.ID
                    _PriceTableItem.Name = Sellable.Name
                    _PriceTableItem.Code = String.Empty
                    _PriceTableItem.Price = DbxPrice.DecimalValue
                End If
                _PriceTableItem.SetIsSaved(True)
                _PriceTable.Sellables.Add(_PriceTableItem)
            End If
            _PriceTableForm.DgvPriceTableSellable.Fill(_PriceTable.Sellables)
            _PriceTableForm.DgvPriceTableItemLayout.Load()
            BtnSave.Enabled = False
            If Not _PriceTableItem.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _PriceTableForm.DgvPriceTableSellable.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _PriceTableItem.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _PriceTableForm.DgvPriceTableSellable.SelectedRows(0).Cells("Order").Value
            _PriceTableForm.EprValidation.Clear()
            _PriceTableForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function HasDuplicatedItem() As Boolean
        Dim TargetItems As List(Of PriceTableSellable)
        If RbtProduct.Checked Then
            TargetItems = _PriceTable.Sellables.Where(Function(x) Not x.SellableID.Equals(_PriceTableItem.SellableID) AndAlso x.Product IsNot Nothing AndAlso x.Product.ID.Equals(_PriceTableItem.Product.ID)).ToList
        Else
            TargetItems = _PriceTable.Sellables.Where(Function(x) Not x.SellableID.Equals(_PriceTableItem.SellableID) AndAlso x.Service IsNot Nothing AndAlso x.Service.ID.Equals(QbxSellable.FreezedPrimaryKey)).ToList
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
    Private Sub QbxSellable_Enter(sender As Object, e As EventArgs) Handles QbxSellable.Enter
        TmrQueriedBox.Stop()
        If RbtProduct.Checked Then
            BtnView.Visible = QbxSellable.IsFreezed And _User.CanWrite(Routine.Product)
            BtnNew.Visible = _User.CanWrite(Routine.Product)
            BtnFilter.Visible = _User.CanAccess(Routine.Product)
        Else
            BtnView.Visible = QbxSellable.IsFreezed And _User.CanWrite(Routine.Service)
            BtnNew.Visible = _User.CanWrite(Routine.Service)
            BtnFilter.Visible = _User.CanAccess(Routine.Service)
        End If
    End Sub
    Private Sub QbxItem_Leave(sender As Object, e As EventArgs) Handles QbxSellable.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxItem_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxSellable.FreezedPrimaryKeyChanged
        If Not _Loading Then
            If RbtProduct.Checked Then
                BtnView.Visible = QbxSellable.IsFreezed And _User.CanWrite(Routine.Product)
            Else
                BtnView.Visible = QbxSellable.IsFreezed And _User.CanWrite(Routine.Service)
            End If
        End If
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Product As Product
        Dim Service As Service
        Dim ProductForm As FrmProduct
        Dim ServiceForm As FrmService
        If RbtProduct.Checked Then
            Product = New Product
            ProductForm = New FrmProduct(Product)
            ProductForm.ShowDialog()
            If Product.ID > 0 Then
                QbxSellable.Freeze(Product.ID)
            End If
        Else
            Service = New Service
            ServiceForm = New FrmService(Service)
            ServiceForm.ShowDialog()
            If Service.ID > 0 Then
                QbxSellable.Freeze(Service.ID)
            End If
        End If
        EprValidation.Clear()
        QbxSellable.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim ProductForm As FrmProduct
        Dim ServiceForm As FrmService
        If RbtProduct.Checked Then
            ProductForm = New FrmProduct(New Product().Load(QbxSellable.FreezedPrimaryKey, True))
            ProductForm.ShowDialog()
        Else
            ServiceForm = New FrmService(New Service().Load(QbxSellable.FreezedPrimaryKey, True))
            ServiceForm.ShowDialog()
        End If
        QbxSellable.Freeze(QbxSellable.FreezedPrimaryKey)
        QbxSellable.Select()
    End Sub    '
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        If RbtProduct.Checked Then
            FilterForm = New FrmFilter(New ProductQueriedBoxFilter(), QbxSellable) With {
                .Text = "Filtro de Produtos"
            }
        Else
            FilterForm = New FrmFilter(New ServiceQueriedBoxFilter(), QbxSellable) With {
                .Text = "Filtro de Serviços"
            }
        End If
        FilterForm.ShowDialog()
        QbxSellable.Select()
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _PriceTableItem = New PriceTableSellable()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PriceTableForm.DgvPriceTableSellable.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _PriceTableItem = _PriceTable.Sellables.Single(Function(x) x.Guid = _PriceTableForm.DgvPriceTableSellable.SelectedRows(0).Cells("Guid").Value)
                _PriceTable.Sellables.Remove(_PriceTableItem)
                _PriceTableForm.DgvPriceTableSellable.Fill(_PriceTable.Sellables)
                _PriceTableForm.DgvPriceTableItemLayout.Load()
                _Deleting = True
                Dispose()
                _PriceTableForm.BtnSave.Enabled = True
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