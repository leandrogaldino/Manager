Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient

Public Class FrmPriceTable
    Private _PriceTable As PriceTable
    Private _PriceTablesForm As FrmPriceTables
    Private _PriceTablesGrid As DataGridView
    Private _Filter As PriceTableFilter
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
    Public Sub New(PriceTable As PriceTable, PriceTablesForm As FrmPriceTables)
        InitializeComponent()
        _PriceTable = PriceTable
        _PriceTablesForm = PriceTablesForm
        _PriceTablesGrid = _PriceTablesForm.DgvData
        _Filter = CType(_PriceTablesForm.PgFilter.SelectedObject, PriceTableFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(PriceTable As PriceTable)
        InitializeComponent()
        _PriceTable = PriceTable
        _User = Locator.GetInstance(Of Session).User
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        TcPriceTable.Height -= TsNavigation.Height
        MinimumSize = Nothing
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvPriceTableItemLayout.Load()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(DgvPriceTableItem, True)
        DgvNavigator.DataGridView = _PriceTablesGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        TcPriceTable.SelectedTab = TabMain
        LblIDValue.Text = _PriceTable.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_PriceTable.Status)
        LblCreationValue.Text = _PriceTable.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _PriceTable.Name
        TxtFilterDescription.Clear()
        If _PriceTable.Items IsNot Nothing Then DgvPriceTableItem.Fill(_PriceTable.Items)
        BtnDelete.Enabled = _PriceTable.ID > 0 And _User.CanDelete(Routine.Service)
        Text = "Tabela de Preço"
        If _PriceTable.Source = PriceTableSource.FromSystem Then
            CMessageBox.Show("Essa é uma tabela de preços do sistema. Você não poderá salvar alterações.", CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        Else
            If _PriceTable.LockInfo.IsLocked And Not _PriceTable.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _PriceTable.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
                CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _PriceTable.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                Text &= " - SOMENTE LEITURA"
            End If
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
            _PriceTable.Load(_PriceTablesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO PT005", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
            If _PriceTablesForm IsNot Nothing Then
                DgvPriceTableItem.Fill(_PriceTable.Items)
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
        _PriceTable = New PriceTable
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PriceTable.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _PriceTable.LockInfo.IsLocked Or (_PriceTable.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _PriceTable.LockInfo.SessionToken) Then
                        _PriceTable.Delete()
                        If _PriceTablesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _PriceTablesForm.DgvPriceTablesLayout.Load()
                            _PriceTablesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _PriceTable.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO PT006", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.PriceTable, _PriceTable.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _PriceTable.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _PriceTable.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub

    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
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

    Private Sub BtnIncludeComplement_Click(sender As Object, e As EventArgs) Handles BtnIncludePriceTableItem.Click
        Dim Form As New FrmPriceTableItem(_PriceTable, New PriceTableItem, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditComplement_Click(sender As Object, e As EventArgs) Handles BtnEditPriceTableItem.Click
        Dim Form As FrmPriceTableItem
        Dim PriceTableItem As PriceTableItem
        If DgvPriceTableItem.SelectedRows.Count = 1 Then
            PriceTableItem = _PriceTable.Items.Single(Function(x) x.Guid = DgvPriceTableItem.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmPriceTableItem(_PriceTable, PriceTableItem, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteCode_Click(sender As Object, e As EventArgs) Handles BtnDeletePriceTableItem.Click
        Dim PriceTableItem As PriceTableItem
        If DgvPriceTableItem.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                PriceTableItem = _PriceTable.Items.Single(Function(x) x.Guid = DgvPriceTableItem.SelectedRows(0).Cells("Guid").Value)
                _PriceTable.Items.Remove(PriceTableItem)
                DgvPriceTableItem.Fill(_PriceTable.Items)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub TcPriceTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcPriceTable.SelectedIndexChanged
        If TcPriceTable.SelectedTab Is TabMain Then
            Size = New Size(400, 225)
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
    Private Sub DgvPriceTableItem_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPriceTableItem.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPriceTableItem.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditPriceTableItem.PerformClick()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TcPriceTable.SelectedTab = TabMain
            TxtName.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        Dim DocumentPath As String = String.Empty
        Dim Success As Boolean
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        If _PriceTable.Source = PriceTableSource.FromSystem Then
            CMessageBox.Show("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois é uma tabela do sistema.")
            Success = False
        ElseIf _PriceTable.LockInfo.IsLocked And _PriceTable.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _PriceTable.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _PriceTable.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _PriceTable.Name = TxtName.Text
                    _PriceTable.SaveChanges()
                    _PriceTable.Lock()
                    LblIDValue.Text = _PriceTable.ID
                    DgvPriceTableItem.Fill(_PriceTable.Items)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.PriceTable)
                    If _PriceTablesForm IsNot Nothing Then
                        _Filter.Filter()
                        _PriceTablesForm.DgvPriceTablesLayout.Load()
                        Row = _PriceTablesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Success = True
                Catch ex As Exception
                    CMessageBox.Show("ERRO PT007", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
    Private Sub TxtKeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterDescription.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterComplement_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterPriceTableItem.TextChanged
        FilterPriceTableItem()
    End Sub
    Private Sub FilterPriceTableItem()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1}",
                                                 "Code LIKE '%@VALUE%'",
                                                 "Name LIKE '%@VALUE%'"
                                            )
        If DgvPriceTableItem.DataSource IsNot Nothing Then
            Table = DgvPriceTableItem.DataSource
            View = Table.DefaultView
            If TxtFilterPriceTableItem.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterPriceTableItem.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterPriceTableItem_Enter(sender As Object, e As EventArgs) Handles TxtFilterPriceTableItem.Enter
        EprInformation.SetError(TsComplement, "Filtrando os campo: Código e Nome.")
        EprInformation.SetIconAlignment(TsComplement, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsComplement, -365)
    End Sub
    Private Sub TxtFilterComplement_Leave(sender As Object, e As EventArgs) Handles TxtFilterPriceTableItem.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterProviderCode_Leave(sender As Object, e As EventArgs)
        EprInformation.Clear()
    End Sub

    Private Sub FrmService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _PriceTable.Unlock()
    End Sub
    Private Sub DgvPriceTableItem_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvPriceTableItem.DataSourceChanged
        FilterPriceTableItem()
    End Sub

    Private Sub DgvPriceTableItem_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPriceTableItem.SelectionChanged
        If DgvPriceTableItem.SelectedRows.Count = 0 Then
            BtnEditPriceTableItem.Enabled = False
            BtnDeletePriceTableItem.Enabled = False
        Else
            BtnEditPriceTableItem.Enabled = True
            BtnDeletePriceTableItem.Enabled = True
        End If
    End Sub
End Class