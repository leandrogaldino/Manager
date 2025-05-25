Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Public Class FrmProduct
    Private _Product As Product
    Private _ProductsForm As FrmProducts
    Private _ProductsGrid As DataGridView
    Private _Filter As ProductFilter
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
    Public Sub New(Product As Product, ProductsForm As FrmProducts)
        InitializeComponent()
        _Product = Product
        _ProductsForm = ProductsForm
        _ProductsGrid = _ProductsForm.DgvData
        _Filter = CType(_ProductsForm.PgFilter.SelectedObject, ProductFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(Product As Product)
        InitializeComponent()
        _Product = Product
        _User = Locator.GetInstance(Of Session).User
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        TcProduct.Height -= TsNavigation.Height
        MinimumSize = Nothing
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvProviderCodeLayout.Load()
        DgvCodeLayout.Load()
        DgvPictureLayout.Load()
        DgvPriceLayout.Load()
        DgvIndicatorLayout.Load()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(DgvProviderCode, True)
        ControlHelper.EnableControlDoubleBuffer(DgvCode, True)
        ControlHelper.EnableControlDoubleBuffer(DgvPicture, True)
        ControlHelper.EnableControlDoubleBuffer(DgvPrice, True)
        ControlHelper.EnableControlDoubleBuffer(DgvIndicator, True)
        DgvNavigator.DataGridView = _ProductsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        TcProduct.SelectedTab = TabMain
        LblIDValue.Text = _Product.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Product.Status)
        LblCreationValue.Text = _Product.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _Product.Name
        TxtInternalName.Text = _Product.InternalName
        QbxFamily.Unfreeze()
        QbxFamily.Freeze(_Product.Family.ID)
        QbxGroup.Unfreeze()
        QbxGroup.Freeze(_Product.Group.ID)
        QbxUnit.Unfreeze()
        QbxUnit.Freeze(_Product.Unit.ID)
        TxtLocation.Text = _Product.Location
        DbxQtyMin.Text = _Product.MinimumQuantity
        DbxQtyMax.Text = _Product.MaximumQuantity
        DbxGrossWeight.Text = _Product.GrossWeight
        DbxNetWeight.Text = _Product.NetWeight
        TxtNote.Text = _Product.Note
        TxtFilterProviderCode.Clear()
        TxtFilterCode.Clear()
        If _Product.ProviderCodes IsNot Nothing Then DgvProviderCode.Fill(_Product.ProviderCodes)
        If _Product.Codes IsNot Nothing Then DgvCode.Fill(_Product.Codes)
        If _Product.Pictures IsNot Nothing Then DgvPicture.Fill(_Product.Pictures)
        If _Product.Prices IsNot Nothing Then DgvPrice.Fill(_Product.Prices)
        If _Product.Indicators IsNot Nothing Then DgvIndicator.Fill(_Product.Indicators)
        BtnDelete.Enabled = _Product.ID > 0 And _User.CanDelete(Routine.Product)
        Text = "Produto"
        If _Product.LockInfo.IsLocked And Not _Product.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Product.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _Product.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
            _Product.Load(_ProductsGrid.SelectedRows(0).Cells("id").Value, True)
            For Each p In _Product.Pictures.ToArray.Reverse
                If Not IO.File.Exists(p.Picture.OriginalFile) Then
                    _Product.Pictures.Remove(p)
                End If
            Next p
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO PD001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
            If _ProductsForm IsNot Nothing Then
                DgvProviderCode.Fill(_Product.ProviderCodes)
                DgvCode.Fill(_Product.Codes)
                DgvPicture.Fill(_Product.Pictures)
                DgvPrice.Fill(_Product.Prices)
                DgvIndicator.Fill(_Product.Indicators)
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
        _Product = New Product
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Product.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Product.LockInfo.IsLocked Or (_Product.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Product.LockInfo.SessionToken) Then
                        _Product.Delete()
                        If _ProductsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _ProductsForm.DgvProductLayout.Load()
                            _ProductsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Product.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO PD002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.Product, _Product.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _Product.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _Product.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub

    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged,
                                                                          TxtInternalName.TextChanged,
                                                                          QbxFamily.TextChanged,
                                                                          QbxGroup.TextChanged,
                                                                          QbxUnit.TextChanged,
                                                                          TxtLocation.TextChanged,
                                                                          DbxQtyMin.TextChanged,
                                                                          DbxQtyMax.TextChanged,
                                                                          DbxGrossWeight.TextChanged,
                                                                          DbxNetWeight.TextChanged,
                                                                          TxtNote.TextChanged, TextBox1.TextChanged, TextBox2.TextChanged

        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtNote_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TxtNote.LinkClicked
        Process.Start(e.LinkText)
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
    Private Sub BtnIncludeProviderCode_Click(sender As Object, e As EventArgs) Handles BtnIncludeProviderCode.Click
        Dim Form As New FrmProductProviderCode(_Product, New ProductProviderCode(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditProviderCode_Click(sender As Object, e As EventArgs) Handles BtnEditProviderCode.Click
        Dim Form As FrmProductProviderCode
        Dim ProviderCode As ProductProviderCode
        If DgvProviderCode.SelectedRows.Count = 1 Then
            ProviderCode = _Product.ProviderCodes.Single(Function(x) x.Guid = DgvProviderCode.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmProductProviderCode(_Product, ProviderCode, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteProviderCode_Click(sender As Object, e As EventArgs) Handles BtnDeleteProviderCode.Click
        Dim ProviderCode As ProductProviderCode
        If DgvProviderCode.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                ProviderCode = _Product.ProviderCodes.Single(Function(x) x.Guid = DgvProviderCode.SelectedRows(0).Cells("Guid").Value)
                _Product.ProviderCodes.Remove(ProviderCode)
                DgvProviderCode.Fill(_Product.ProviderCodes)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnIncludeCode_Click(sender As Object, e As EventArgs) Handles BtnIncludeCode.Click
        Dim Form As New FrmProductCode(_Product, New ProductCode, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditCode_Click(sender As Object, e As EventArgs) Handles BtnEditCode.Click
        Dim Form As FrmProductCode
        Dim Code As ProductCode
        If DgvCode.SelectedRows.Count = 1 Then
            Code = _Product.Codes.Single(Function(x) x.Guid = DgvCode.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmProductCode(_Product, Code, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteCode_Click(sender As Object, e As EventArgs) Handles BtnDeleteCode.Click
        Dim Code As ProductCode
        If DgvCode.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Code = _Product.Codes.Single(Function(x) x.Guid = DgvCode.SelectedRows(0).Cells("Guid").Value)
                _Product.Codes.Remove(Code)
                DgvCode.Fill(_Product.Codes)
                BtnSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub TcPerson_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcProduct.SelectedIndexChanged
        If TcProduct.SelectedTab Is TabMain Then
            Size = New Size(630, 355)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvPrice_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Price").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N2"
        End If
    End Sub
    Private Sub DgvPicture_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvPicture.CellFormatting
        Dim Dgv As DataGridView = sender
        Dgv.Rows(e.RowIndex).Height = 60
        If e.ColumnIndex = Dgv.Columns("Picture").Index Then
            CType(Dgv.Columns(e.ColumnIndex), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
        End If
    End Sub
    Private Sub DgvProviderCode_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvProviderCode.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvProviderCode.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditProviderCode.PerformClick()
        End If
    End Sub
    Private Sub DgvCode_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCode.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCode.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditCode.PerformClick()
        End If
    End Sub

    Private Sub DgvPicture_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPicture.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPicture.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditPicture.PerformClick()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            TxtName.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtInternalName.Text) Then
            EprValidation.SetError(LblInternalName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblInternalName, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            TxtInternalName.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxFamily.Text) Then
            EprValidation.SetError(LblFamily, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblFamily, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            QbxFamily.Select()
            Return False
        ElseIf Not QbxFamily.IsFreezed Then
            EprValidation.SetError(LblFamily, "Família do produto não encontrada.")
            EprValidation.SetIconAlignment(LblFamily, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            QbxFamily.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxGroup.Text) Then
            EprValidation.SetError(LblGroup, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblGroup, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            QbxGroup.Select()
            Return False
        ElseIf Not QbxGroup.IsFreezed Then
            EprValidation.SetError(LblGroup, "Grupo do produto não encontrado.")
            EprValidation.SetIconAlignment(LblGroup, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            QbxGroup.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxUnit.Text) Then
            EprValidation.SetError(LblUnit, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblUnit, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            QbxUnit.Select()
            Return False
        ElseIf Not QbxUnit.IsFreezed Then
            EprValidation.SetError(LblUnit, "Unidade de medida do produto não encontrada.")
            EprValidation.SetIconAlignment(LblUnit, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            QbxUnit.Select()
            Return False
        ElseIf DbxQtyMin.DecimalValue > DbxQtyMax.DecimalValue Then
            EprValidation.SetError(LblQtyMin, "A quanidade mínima não pode ser maior que a quantidade máxima.")
            EprValidation.SetIconAlignment(LblQtyMin, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            DbxQtyMin.Select()
            Return False
        ElseIf DbxGrossWeight.DecimalValue < DbxNetWeight.DecimalValue Then
            EprValidation.SetError(LblGrossWeight, "O peso bruto não pode ser menor que o peso líquido.")
            EprValidation.SetIconAlignment(LblGrossWeight, ErrorIconAlignment.MiddleRight)
            TcProduct.SelectedTab = TabMain
            DbxGrossWeight.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        Dim DocumentPath As String = String.Empty
        Dim Success As Boolean
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        TxtInternalName.Text = TxtInternalName.Text.Trim.ToUnaccented()
        TxtLocation.Text = TxtLocation.Text.Trim.ToUnaccented()
        TxtNote.Text = TxtNote.Text.ToUpper.ToUnaccented()
        If _Product.LockInfo.IsLocked And _Product.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Product.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Product.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _Product.Name = TxtName.Text
                    _Product.InternalName = TxtInternalName.Text
                    _Product.Family = New ProductFamily().Load(QbxFamily.FreezedPrimaryKey, False)
                    _Product.Group = New ProductGroup().Load(QbxGroup.FreezedPrimaryKey, False)
                    _Product.Unit = New ProductUnit().Load(QbxUnit.FreezedPrimaryKey, False)
                    _Product.Location = TxtLocation.Text
                    _Product.MinimumQuantity = DbxQtyMin.DecimalValue
                    _Product.MaximumQuantity = DbxQtyMax.DecimalValue
                    _Product.GrossWeight = DbxGrossWeight.DecimalValue
                    _Product.NetWeight = DbxNetWeight.DecimalValue
                    _Product.Note = TxtNote.Text
                    _Product.SaveChanges()
                    _Product.Lock()
                    LblIDValue.Text = _Product.ID
                    DgvProviderCode.Fill(_Product.ProviderCodes)
                    DgvCode.Fill(_Product.Codes)
                    DgvPicture.Fill(_Product.Pictures)
                    DgvPrice.Fill(_Product.Prices)
                    DgvIndicator.Fill(_Product.Indicators)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.Product)
                    If _ProductsForm IsNot Nothing Then
                        _Filter.Filter()
                        _ProductsForm.DgvProductLayout.Load()
                        Row = _ProductsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Success = True
                Catch ex As Exception
                    CMessageBox.Show("ERRO PD003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Success = False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Success = False
            End If
        End If
        Return Success
    End Function
    Private Sub TxtKeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterProviderCode.KeyPress,
                                                                                            TxtFilterCode.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterProviderCode_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterProviderCode.TextChanged
        FilterProviderCode()
    End Sub
    Private Sub FilterProviderCode()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1}",
                                                 "Code LIKE '%@VALUE%'",
                                                 "Convert([Provider], 'System.String') LIKE '%@VALUE%'"
                                            )
        If DgvProviderCode.DataSource IsNot Nothing Then
            Table = DgvProviderCode.DataSource
            View = Table.DefaultView
            If TxtFilterProviderCode.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterProviderCode.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterCode_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterCode.TextChanged
        FilterCode()
    End Sub
    Private Sub FilterCode()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1}",
                                                 "Name LIKE '%@VALUE%'",
                                                 "Code LIKE '%@VALUE%'"
                                            )
        If DgvCode.DataSource IsNot Nothing Then
            Table = DgvCode.DataSource
            View = Table.DefaultView
            If TxtFilterCode.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterCode.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterPicture_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterPicture.TextChanged
        FilterPicture()
    End Sub
    Private Sub FilterPicture()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0}", "Caption LIKE '%@VALUE%'")
        If DgvPicture.DataSource IsNot Nothing Then
            Table = DgvPicture.DataSource
            View = Table.DefaultView
            If TxtFilterPicture.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterPicture.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TmrQueriedBoxFamily_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBoxFamily.Tick
        BtnViewFamily.Visible = False
        BtnNewFamily.Visible = False
        BtnFilterFamily.Visible = False
        TmrQueriedBoxFamily.Stop()
    End Sub
    Private Sub QbxFamily_Enter(sender As Object, e As EventArgs) Handles QbxFamily.Enter
        TmrQueriedBoxFamily.Stop()
        BtnViewFamily.Visible = QbxFamily.IsFreezed And _User.CanWrite(Routine.ProductFamily)
        BtnNewFamily.Visible = _User.CanWrite(Routine.ProductFamily)
        BtnFilterFamily.Visible = _User.CanAccess(Routine.ProductFamily)
    End Sub
    Private Sub QbxFamily_Leave(sender As Object, e As EventArgs) Handles QbxFamily.Leave
        TmrQueriedBoxFamily.Stop()
        TmrQueriedBoxFamily.Start()
    End Sub
    Private Sub QbxFamily_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxFamily.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewFamily.Visible = QbxFamily.IsFreezed And _User.CanWrite(Routine.ProductFamily)
    End Sub
    Private Sub BtnNewFamily_Click(sender As Object, e As EventArgs) Handles BtnNewFamily.Click
        Dim Family As ProductFamily
        Dim Form As FrmProductFamily
        Family = New ProductFamily
        Form = New FrmProductFamily(Family)
        Form.ShowDialog()
        EprValidation.Clear()
        If Family.ID > 0 Then
            QbxFamily.Freeze(Family.ID)
        End If
        QbxFamily.Select()
    End Sub
    Private Sub BtnViewFamily_Click(sender As Object, e As EventArgs) Handles BtnViewFamily.Click
        Dim Form As New FrmProductFamily(New ProductFamily().Load(QbxFamily.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxFamily.Freeze(QbxFamily.FreezedPrimaryKey)
        QbxFamily.Select()
    End Sub
    Private Sub BtnFilterFamily_Click(sender As Object, e As EventArgs) Handles BtnFilterFamily.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New ProductFamilyQueriedBoxFilter(), QbxFamily)
        FilterForm.Text = "Filtro de Família de Produto"
        FilterForm.ShowDialog()
        QbxFamily.Select()
    End Sub
    Private Sub TmrQueriedBoxGroup_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBoxGroup.Tick
        BtnViewGroup.Visible = False
        BtnNewGroup.Visible = False
        BtnFilterGroup.Visible = False
        TmrQueriedBoxGroup.Stop()
    End Sub
    Private Sub QbxGroup_Enter(sender As Object, e As EventArgs) Handles QbxGroup.Enter
        TmrQueriedBoxGroup.Stop()
        BtnViewGroup.Visible = QbxGroup.IsFreezed And _User.CanWrite(Routine.ProductGroup)
        BtnNewGroup.Visible = _User.CanWrite(Routine.ProductGroup)
        BtnFilterGroup.Visible = _User.CanAccess(Routine.ProductGroup)
    End Sub
    Private Sub QbxGroup_Leave(sender As Object, e As EventArgs) Handles QbxGroup.Leave
        TmrQueriedBoxGroup.Stop()
        TmrQueriedBoxGroup.Start()
    End Sub
    Private Sub QbxGroup_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxGroup.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewGroup.Visible = QbxGroup.IsFreezed And _User.CanWrite(Routine.ProductGroup)
    End Sub
    Private Sub BtnNewGroup_Click(sender As Object, e As EventArgs) Handles BtnNewGroup.Click
        Dim Group As ProductGroup
        Dim Form As FrmProductGroup
        Group = New ProductGroup
        Form = New FrmProductGroup(Group)
        Form.ShowDialog()
        EprValidation.Clear()
        If Group.ID > 0 Then
            QbxGroup.Freeze(Group.ID)
        End If
        QbxGroup.Select()
    End Sub
    Private Sub BtnViewGroup_Click(sender As Object, e As EventArgs) Handles BtnViewGroup.Click
        Dim Form As New FrmProductGroup(New ProductGroup().Load(QbxGroup.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxGroup.Freeze(QbxGroup.FreezedPrimaryKey)
        QbxGroup.Select()
    End Sub
    Private Sub BtnFilterGroup_Click(sender As Object, e As EventArgs) Handles BtnFilterGroup.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New ProductGroupQueriedBoxFilter(), QbxGroup)
        FilterForm.Text = "Filtro de Grupo de Produto"
        FilterForm.ShowDialog()
        QbxGroup.Select()
    End Sub
    Private Sub BtnIncludePicture_Click(sender As Object, e As EventArgs) Handles BtnIncludePicture.Click
        Dim Form As New FrmProductPicture(_Product, New ProductPicture(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditPicture_Click(sender As Object, e As EventArgs) Handles BtnEditPicture.Click
        Dim Form As FrmProductPicture
        Dim Picture As ProductPicture
        If DgvPicture.SelectedRows.Count = 1 Then
            Picture = _Product.Pictures.Single(Function(x) x.Guid = DgvPicture.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmProductPicture(_Product, Picture, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeletePicture_Click(sender As Object, e As EventArgs) Handles BtnDeletePicture.Click
        Dim Picture As ProductPicture
        If DgvPicture.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Picture = _Product.Pictures.Single(Function(x) x.Guid = DgvPicture.SelectedRows(0).Cells("Guid").Value)
                _Product.Pictures.Remove(Picture)
                DgvPicture.Fill(_Product.Pictures)
                BtnSave.Enabled = True
            End If
        End If
    End Sub


















    Private Sub BtnIncludePrice_Click(sender As Object, e As EventArgs) Handles BtnIncludePrice.Click
        Dim Form As New FrmProductPrice(_Product, New ProductPrice, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditPrice_Click(sender As Object, e As EventArgs) Handles BtnEditPrice.Click
        Dim Form As FrmProductPrice
        Dim Price As ProductPrice
        If DgvPrice.SelectedRows.Count = 1 Then
            Price = _Product.Prices.Single(Function(x) x.Guid = DgvPrice.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmProductPrice(_Product, Price, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeletePrice_Click(sender As Object, e As EventArgs) Handles BtnDeletePrice.Click
        Dim Price As ProductPrice
        If DgvPrice.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Price = _Product.Prices.Single(Function(x) x.Guid = DgvPrice.SelectedRows(0).Cells("Guid").Value)
                _Product.Prices.Remove(Price)
                DgvPrice.Fill(_Product.Prices)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DgvPrice_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPrice.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPrice.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditPrice.PerformClick()
        End If
    End Sub
    Private Sub FilterPrice()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0}", "PriceTableName LIKE '%@VALUE%'")
        If DgvPrice.DataSource IsNot Nothing Then
            Table = DgvPrice.DataSource
            View = Table.DefaultView
            If TxtFilterPrice.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterPrice.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterPrice_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterPrice.TextChanged
        FilterPrice()
    End Sub
    Private Sub TxtFilterPrice_Enter(sender As Object, e As EventArgs) Handles TxtFilterPrice.Enter
        EprInformation.SetError(TsPrice, "Filtrando os campo: Tabela de Preços.")
        EprInformation.SetIconAlignment(TsPrice, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsPrice, -365)
    End Sub
    Private Sub TxtFilterPrice_Leave(sender As Object, e As EventArgs) Handles TxtFilterPrice.Leave
        EprInformation.Clear()
    End Sub

    Private Sub DgvPrice_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvPrice.DataSourceChanged
        FilterPrice()
    End Sub
    Private Sub DgvPrice_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPrice.SelectionChanged
        If DgvPrice.SelectedRows.Count = 0 Then
            BtnEditPrice.Enabled = False
            BtnDeletePrice.Enabled = False
        Else
            BtnEditPrice.Enabled = True
            BtnDeletePrice.Enabled = True
        End If
    End Sub
























    Private Sub TxtName_Leave(sender As Object, e As EventArgs) Handles TxtName.Leave
        If TxtInternalName.Text = Nothing Then TxtInternalName.Text = TxtName.Text
    End Sub
    Private Sub TxtFilterCode_Enter(sender As Object, e As EventArgs) Handles TxtFilterCode.Enter
        EprInformation.SetError(TsCode, "Filtrando os campos: Nome e Código")
        EprInformation.SetIconAlignment(TsCode, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsCode, -365)
    End Sub
    Private Sub TxtFilterCode_Leave(sender As Object, e As EventArgs) Handles TxtFilterCode.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterProviderCode_Enter(sender As Object, e As EventArgs) Handles TxtFilterProviderCode.Enter
        EprInformation.SetError(TsProviderCode, "Filtrando os campos: Código e Fornecedor")
        EprInformation.SetIconAlignment(TsProviderCode, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsProviderCode, -365)
    End Sub
    Private Sub TxtFilterProviderCode_Leave(sender As Object, e As EventArgs) Handles TxtFilterProviderCode.Leave
        EprInformation.Clear()
    End Sub

    Private Sub TxtFilterPicture_Enter(sender As Object, e As EventArgs) Handles TxtFilterPicture.Enter
        EprInformation.SetError(TsPicture, "Filtrando o campo: Legenda")
        EprInformation.SetIconAlignment(TsPicture, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsPicture, -365)
    End Sub
    Private Sub TxtFilterPicture_Leave(sender As Object, e As EventArgs) Handles TxtFilterPicture.Leave
        EprInformation.Clear()
    End Sub
    Private Sub FrmProduct_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Product.Unlock()
    End Sub
    Private Sub DgvProviderCode_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvProviderCode.DataSourceChanged
        FilterProviderCode()
    End Sub
    Private Sub DgvCode_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvCode.DataSourceChanged
        FilterCode()
    End Sub
    Private Sub DgvPicture_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvPicture.DataSourceChanged
        FilterPicture()
    End Sub
    Private Sub DgvPicture_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPicture.SelectionChanged
        If DgvPicture.SelectedRows.Count = 0 Then
            BtnEditPicture.Enabled = False
            BtnDeletePicture.Enabled = False
        Else
            BtnEditPicture.Enabled = True
            BtnDeletePicture.Enabled = True
        End If
    End Sub
    Private Sub DgvCode_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCode.SelectionChanged
        If DgvCode.SelectedRows.Count = 0 Then
            BtnEditCode.Enabled = False
            BtnDeleteCode.Enabled = False
        Else
            BtnEditCode.Enabled = True
            BtnDeleteCode.Enabled = True
        End If
    End Sub
    Private Sub DgvProviderCode_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProviderCode.SelectionChanged
        If DgvProviderCode.SelectedRows.Count = 0 Then
            BtnEditProviderCode.Enabled = False
            BtnDeleteProviderCode.Enabled = False
        Else
            BtnEditProviderCode.Enabled = True
            BtnDeleteProviderCode.Enabled = True
        End If
    End Sub
End Class