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
    Public Sub New(Compressor As Compressor, ElapsedDaySellable As CompressorSellable, CompressorForm As FrmCompressor)
        InitializeComponent()
        _Compressor = Compressor
        _ElapsedDaySellable = ElapsedDaySellable
        _CompressorForm = CompressorForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _CompressorForm.DgvCompressorElapsedDaySellable
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_ElapsedDaySellable.IsSaved, _CompressorForm.DgvCompressorElapsedDaySellable.SelectedRows(0).Cells("Order").Value, 0)
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_ElapsedDaySellable.Status)
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
        If _CompressorForm.DgvCompressorElapsedDaySellable.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ElapsedDaySellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _CompressorForm.DgvCompressorElapsedDaySellable.SelectedRows(0).Cells("Guid").Value)
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
        Using Form As New FrmLog(Routine.CompressorSellable, _ElapsedDaySellable.ID)
            Form.ShowDialog()
        End Using
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
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles QbxSellable.TextChanged, DbxQuantity.TextChanged
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
            If _ElapsedDaySellable.IsSaved Then
                With _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid)
                    .SellableID = QbxSellable.FreezedPrimaryKey
                    .Quantity = DbxQuantity.DecimalValue
                End With
                If RbtProduct.Checked Then
                    With _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid)
                        .SellableType = SellableType.Product
                        .Sellable = New Lazy(Of Sellable)(Function() New Product().Load(QbxSellable.FreezedPrimaryKey, False))
                        .Name = QbxSellable.GetRawFreezedValueOf("product", "name")
                        .Code = QbxSellable.GetRawFreezedValueOf("productprovidercode", "code")
                    End With
                Else
                    With _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _ElapsedDaySellable.Guid)
                        .SellableType = SellableType.Service
                        .Sellable = New Lazy(Of Sellable)(Function() New Service().Load(QbxSellable.FreezedPrimaryKey, False))
                        .Name = QbxSellable.GetRawFreezedValueOf("service", "name")
                        .Code = String.Empty
                    End With
                End If
            Else
                _ElapsedDaySellable = New CompressorSellable(CompressorSellableControlType.ElapsedDay)
                With _ElapsedDaySellable
                    .SellableID = QbxSellable.FreezedPrimaryKey
                    .Quantity = DbxQuantity.DecimalValue
                End With
                If RbtProduct.Checked Then
                    With _ElapsedDaySellable
                        .SellableType = SellableType.Product
                        .Sellable = New Lazy(Of Sellable)(Function() New Product().Load(QbxSellable.FreezedPrimaryKey, False))
                        .Name = QbxSellable.GetRawFreezedValueOf("product", "name")
                        .Code = QbxSellable.GetRawFreezedValueOf("productprovidercode", "code")
                    End With
                Else
                    With _ElapsedDaySellable
                        .SellableType = SellableType.Service
                        .Sellable = New Lazy(Of Sellable)(Function() New Service().Load(QbxSellable.FreezedPrimaryKey, False))
                        .Name = QbxSellable.GetRawFreezedValueOf("service", "name")
                        .Code = String.Empty
                    End With
                End If
                If HasDuplicatedItem() Then Return False
                _ElapsedDaySellable.SetIsSaved(True)
                _Compressor.ElapsedDaySellables.Add(_ElapsedDaySellable)
            End If
            _CompressorForm.DgvCompressorElapsedDaySellable.Fill(_Compressor.ElapsedDaySellables)
            _CompressorForm.DgvlCompressorElapsedDaySellable.Load()
            BtnSave.Enabled = False
            If Not _ElapsedDaySellable.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _CompressorForm.DgvCompressorElapsedDaySellable.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _ElapsedDaySellable.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _CompressorForm.DgvCompressorElapsedDaySellable.SelectedRows(0).Cells("Order").Value
            _CompressorForm.EprValidation.Clear()
            _CompressorForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function

    Private Function HasDuplicatedItem() As Boolean
        Dim WorkedHourItems As List(Of CompressorSellable)
        Dim ElapsedDayItems As List(Of CompressorSellable)
        Dim TargetItems As List(Of CompressorSellable)
        If RbtProduct.Checked Then
            WorkedHourItems = _Compressor.WorkedHourSellables.Where(Function(x) x.SellableID.Equals(_ElapsedDaySellable.SellableID) AndAlso x.SellableType = SellableType.Product AndAlso x.SellableID.Equals(QbxSellable.FreezedPrimaryKey)).ToList
            ElapsedDayItems = _Compressor.ElapsedDaySellables.Where(Function(x) x.SellableID.Equals(_ElapsedDaySellable.SellableID) AndAlso x.SellableType = SellableType.Product AndAlso x.SellableID.Equals(QbxSellable.FreezedPrimaryKey)).ToList
        Else
            WorkedHourItems = _Compressor.WorkedHourSellables.Where(Function(x) x.SellableID.Equals(_ElapsedDaySellable.SellableID) AndAlso x.SellableType = SellableType.Service AndAlso x.SellableID.Equals(QbxSellable.FreezedPrimaryKey)).ToList
            ElapsedDayItems = _Compressor.ElapsedDaySellables.Where(Function(x) x.SellableID.Equals(_ElapsedDaySellable.SellableID) AndAlso x.SellableType = SellableType.Service AndAlso x.SellableID.Equals(QbxSellable.FreezedPrimaryKey)).ToList
        End If
        TargetItems = WorkedHourItems.Concat(ElapsedDayItems).ToList
        If TargetItems.Any() Then
            If RbtProduct.Checked Then
                CMessageBox.Show("Esse produto já foi incluído no compressor.", CMessageBoxType.Information)
            Else
                CMessageBox.Show("Esse serviço já foi incluído no compressor.", CMessageBoxType.Information)
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
    Private Sub QbxSellable_Leave(sender As Object, e As EventArgs) Handles QbxSellable.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxSellable_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxSellable.FreezedPrimaryKeyChanged
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
        If RbtProduct.Checked Then
            Product = New Product
            Using Form As New FrmProduct(Product)
                Form.ShowDialog()
            End Using
            If Product.ID > 0 Then
                QbxSellable.Freeze(Product.ID)
            End If
        Else
            Service = New Service
            Using Form As New FrmService(Service)
                Form.ShowDialog()
            End Using
            If Service.ID > 0 Then
                QbxSellable.Freeze(Service.ID)
            End If
        End If
        EprValidation.Clear()
        QbxSellable.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        If RbtProduct.Checked Then
            Using Form As New FrmProduct(New Product().Load(QbxSellable.FreezedPrimaryKey, True))
                Form.ShowDialog()
            End Using
        Else
            Using Form As New FrmService(New Service().Load(QbxSellable.FreezedPrimaryKey, True))
                Form.ShowDialog()
            End Using
        End If
        QbxSellable.Freeze(QbxSellable.FreezedPrimaryKey)
        QbxSellable.Select()
    End Sub    '
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        If RbtProduct.Checked Then
            Using Form As New FrmFilter(New ProductQueriedBoxFilter(), QbxSellable) With {.Text = "Filtro de Produtos"}
                Form.ShowDialog()
            End Using
        Else
            Using Form As New FrmFilter(New ServiceQueriedBoxFilter(), QbxSellable) With {.Text = "Filtro de Serviços"}
                Form.ShowDialog()
            End Using
        End If
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
        If _CompressorForm.DgvCompressorElapsedDaySellable.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ElapsedDaySellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = _CompressorForm.DgvCompressorElapsedDaySellable.SelectedRows(0).Cells("Guid").Value)
                _Compressor.ElapsedDaySellables.Remove(_ElapsedDaySellable)
                _CompressorForm.DgvCompressorElapsedDaySellable.Fill(_Compressor.ElapsedDaySellables)
                _CompressorForm.DgvlCompressorElapsedDaySellable.Load()
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
        QbxSellable.Suffix = String.Empty
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
        QbxSellable.Suffix = " - "
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