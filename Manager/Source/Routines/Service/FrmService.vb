Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Public Class FrmService
    Private _Service As Service
    Private _ServicesForm As FrmServices
    Private _ServicesGrid As DataGridView
    Private _Filter As ServiceFilter
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
    Public Sub New(Service As Service, ServicesForm As FrmServices)
        InitializeComponent()
        _Service = Service
        _ServicesForm = ServicesForm
        _ServicesGrid = _ServicesForm.DgvData
        _Filter = CType(_ServicesForm.PgFilter.SelectedObject, ServiceFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(Service As Service)
        InitializeComponent()
        _Service = Service
        _User = Locator.GetInstance(Of Session).User
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        TcService.Height -= TsNavigation.Height
        MinimumSize = Nothing
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvCodeLayout.Load()
        DgvPriceLayout.Load()
        DgvComplementLayout.Load()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(DgvCode, True)
        ControlHelper.EnableControlDoubleBuffer(DgvPrice, True)
        ControlHelper.EnableControlDoubleBuffer(DgvComplement, True)
        DgvNavigator.DataGridView = _ServicesGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        TcService.SelectedTab = TabMain
        LblIDValue.Text = _Service.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Service.Status)
        LblCreationValue.Text = _Service.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _Service.Name
        TxtNote.Text = _Service.Note
        TxtFilterCode.Clear()
        TxtFilterDescription.Clear()
        TxtFilterPrice.Clear()
        If _Service.Codes IsNot Nothing Then DgvCode.Fill(_Service.Codes)
        If _Service.Prices IsNot Nothing Then DgvPrice.Fill(_Service.Prices)
        If _Service.Complements IsNot Nothing Then DgvComplement.Fill(_Service.Complements)
        BtnDelete.Enabled = _Service.ID > 0 And _User.CanDelete(Routine.Service)
        Text = "Serviço"
        If _Service.LockInfo.IsLocked And Not _Service.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Service.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _Service.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
            _Service.Load(_ServicesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO SV005", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
            If _ServicesForm IsNot Nothing Then
                DgvCode.Fill(_Service.Codes)
                DgvPrice.Fill(_Service.Prices)
                DgvComplement.Fill(_Service.Complements)
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
        _Service = New Service
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Service.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Service.LockInfo.IsLocked Or (_Service.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Service.LockInfo.SessionToken) Then
                        _Service.Delete()
                        If _ServicesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _ServicesForm.DgvServiceLayout.Load()
                            _ServicesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Service.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO SV006", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.Service, _Service.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _Service.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _Service.Status = SimpleStatus.Inactive Then
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
                                                                          TxtNote.TextChanged

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
    Private Sub BtnIncludeCode_Click(sender As Object, e As EventArgs) Handles BtnIncludeCode.Click
        Dim Form As New FrmServiceCode(_Service, New ServiceCode, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditCode_Click(sender As Object, e As EventArgs) Handles BtnEditCode.Click
        Dim Form As FrmServiceCode
        Dim Code As ServiceCode
        If DgvCode.SelectedRows.Count = 1 Then
            Code = _Service.Codes.Single(Function(x) x.Guid = DgvCode.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmServiceCode(_Service, Code, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteCode_Click(sender As Object, e As EventArgs) Handles BtnDeleteCode.Click
        Dim Code As ServiceCode
        If DgvCode.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Code = _Service.Codes.Single(Function(x) x.Guid = DgvCode.SelectedRows(0).Cells("Guid").Value)
                _Service.Codes.Remove(Code)
                DgvCode.Fill(_Service.Codes)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnIncludePrice_Click(sender As Object, e As EventArgs) Handles BtnIncludePrice.Click
        Dim Form As New FrmServicePrice(_Service, New ServicePrice, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditPrice_Click(sender As Object, e As EventArgs) Handles BtnEditPrice.Click
        Dim Form As FrmServicePrice
        Dim Price As ServicePrice
        If DgvPrice.SelectedRows.Count = 1 Then
            Price = _Service.Prices.Single(Function(x) x.Guid = DgvPrice.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmServicePrice(_Service, Price, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeletePrice_Click(sender As Object, e As EventArgs) Handles BtnDeletePrice.Click
        Dim Price As ServicePrice
        If DgvPrice.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Price = _Service.Prices.Single(Function(x) x.Guid = DgvPrice.SelectedRows(0).Cells("Guid").Value)
                _Service.Prices.Remove(Price)
                DgvPrice.Fill(_Service.Prices)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnIncludeComplement_Click(sender As Object, e As EventArgs) Handles BtnIncludeComplement.Click
        Dim Form As New FrmServiceComplement(_Service, New ServiceComplement, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditComplement_Click(sender As Object, e As EventArgs) Handles BtnEditComplement.Click
        Dim Form As FrmServiceComplement
        Dim Complement As ServiceComplement
        If DgvComplement.SelectedRows.Count = 1 Then
            Complement = _Service.Complements.Single(Function(x) x.Guid = DgvComplement.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmServiceComplement(_Service, Complement, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteComplement_Click(sender As Object, e As EventArgs) Handles BtnDeleteComplement.Click
        Dim Complement As ServiceComplement
        If DgvComplement.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Complement = _Service.Complements.Single(Function(x) x.Guid = DgvComplement.SelectedRows(0).Cells("Guid").Value)
                _Service.Complements.Remove(Complement)
                DgvComplement.Fill(_Service.Complements)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub TcPerson_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcService.SelectedIndexChanged
        If TcService.SelectedTab Is TabMain Then
            Size = New Size(460, 225)
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
    Private Sub DgvCode_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCode.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCode.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditCode.PerformClick()
        End If
    End Sub
    Private Sub DgvPrice_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPrice.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPrice.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditPrice.PerformClick()
        End If
    End Sub
    Private Sub DgvComplement_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvComplement.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvComplement.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditComplement.PerformClick()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TcService.SelectedTab = TabMain
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
        TxtNote.Text = TxtNote.Text.ToUpper.ToUnaccented()
        If _Service.LockInfo.IsLocked And _Service.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Service.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Service.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _Service.Name = TxtName.Text
                    _Service.Note = TxtNote.Text
                    _Service.SaveChanges()
                    _Service.Lock()
                    LblIDValue.Text = _Service.ID
                    DgvCode.Fill(_Service.Prices)
                    DgvComplement.Fill(_Service.Complements)
                    DgvPrice.Fill(_Service.Prices)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.Service)
                    If _ServicesForm IsNot Nothing Then
                        _Filter.Filter()
                        _ServicesForm.DgvServiceLayout.Load()
                        Row = _ServicesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Success = True
                Catch ex As Exception
                    CMessageBox.Show("ERRO SV007", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
    Private Sub TxtKeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterCode.KeyPress, TxtFilterPrice.KeyPress, TxtFilterDescription.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub FilterCode()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1}", "Name LIKE '%@VALUE%'", "Code LIKE '%@VALUE%'")
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
    Private Sub TxtFilterCode_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterCode.TextChanged
        FilterCode()
    End Sub

    Private Sub TxtFilterCode_Enter(sender As Object, e As EventArgs) Handles TxtFilterCode.Enter
        EprInformation.SetError(TsCode, "Filtrando os campo: Nome e Código.")
        EprInformation.SetIconAlignment(TsCode, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsCode, -365)
    End Sub
    Private Sub TxtFilterCode_Leave(sender As Object, e As EventArgs) Handles TxtFilterCode.Leave
        EprInformation.Clear()
    End Sub

    Private Sub DgvCode_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvCode.DataSourceChanged
        FilterCode()
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
    Private Sub TxtFilterComplement_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterComplement.TextChanged
        FilterComplement()
    End Sub
    Private Sub FilterComplement()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0}", "Complement LIKE '%@VALUE%'")
        If DgvComplement.DataSource IsNot Nothing Then
            Table = DgvComplement.DataSource
            View = Table.DefaultView
            If TxtFilterComplement.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterComplement.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterComplement_Enter(sender As Object, e As EventArgs) Handles TxtFilterComplement.Enter
        EprInformation.SetError(TsComplement, "Filtrando os campo: Complemento.")
        EprInformation.SetIconAlignment(TsComplement, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsComplement, -365)
    End Sub
    Private Sub TxtFilterComplement_Leave(sender As Object, e As EventArgs) Handles TxtFilterComplement.Leave
        EprInformation.Clear()
    End Sub
    Private Sub DgvComplement_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvComplement.DataSourceChanged
        FilterComplement()
    End Sub
    Private Sub DgvComplement_SelectionChanged(sender As Object, e As EventArgs) Handles DgvComplement.SelectionChanged
        If DgvComplement.SelectedRows.Count = 0 Then
            BtnEditComplement.Enabled = False
            BtnDeleteComplement.Enabled = False
        Else
            BtnEditComplement.Enabled = True
            BtnDeleteComplement.Enabled = True
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
    Private Sub FrmService_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Service.Unlock()
    End Sub
End Class