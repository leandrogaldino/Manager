Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports System.IO
Public Class FrmCashItem
    Private _CashForm As FrmCash
    Private _Cash As Cash
    Private _CashItem As CashItem
    Private _CashItemShadow As CashItem
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _CategoryList As List(Of String)
    Private _Suggestions As New AutoCompleteStringCollection
    Private _SuggestionsFile As String = Path.Combine(Locator.GetInstance(Of Session).UserDirectoryLocation, "CashItemSuggestion.txt")
    Private Sub TxtDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDescription.KeyDown
        Dim Suggestion As String
        If e.KeyCode = Keys.Delete Then
            Suggestion = TxtDescription.Text
            If TxtDescription.AutoCompleteCustomSource.Contains(Suggestion) Then
                TxtDescription.AutoCompleteCustomSource.Remove(Suggestion)
                Me.Invoke(Sub() SaveSuggestions())
            End If
            TxtDescription.Text = Nothing
        End If
    End Sub
    Private Sub LoadSuggestions()
        If Not File.Exists(_SuggestionsFile) Then
            Using Writer As New StreamWriter(_SuggestionsFile, False, System.Text.Encoding.UTF8)
                Writer.Close()
            End Using
        End If
        _Suggestions.AddRange(IO.File.ReadLines(_SuggestionsFile).ToArray)
        DistinctSuggestions()
        TxtDescription.AutoCompleteCustomSource = _Suggestions
    End Sub
    Private Sub SaveSuggestions()
        If Not File.Exists(_SuggestionsFile) Then
            Dim Writer As New StreamWriter(_SuggestionsFile, False, System.Text.Encoding.UTF8)
            Writer.Close()
        End If
        DistinctSuggestions()
        IO.File.WriteAllLines(_SuggestionsFile, AutoCompleteStringCollectionToList())
    End Sub
    Private Sub DistinctSuggestions()
        Dim List As New List(Of String)
        For Each s In _Suggestions
            List.Add(s)
        Next s
        List = List.Distinct.ToList()
        _Suggestions.Clear()
        _Suggestions.AddRange(List.ToArray)
    End Sub
    Private Function AutoCompleteStringCollectionToList() As List(Of String)
        Dim List As New List(Of String)
        For Each s In _Suggestions
            List.Add(s)
        Next s
        Return List
    End Function

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
    Public Sub New(Cash As Cash, CashItem As CashItem, CashForm As FrmCash)
        InitializeComponent()
        _Cash = Cash
        _CashItem = CashItem
        _CashItemShadow = CashItem.Clone()
        _CashForm = CashForm
        _CategoryList = EnumHelper.GetEnumDescriptions(Of CashItemCategory).ToList()
        _CategoryList.Sort()
        LoadForm()
        DgvNavigator.DataGridView = _CashForm.DgvCashItem
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.CanAccess(Routine.Log)
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvResponsiblesLayout.Load()
        LoadSuggestions()
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        Dim Response As DialogResult
        Dim Revert As Boolean
        If BtnSave.Enabled Then
            Response = CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo)
            If Response = DialogResult.No Then
                Revert = True
            ElseIf Response = DialogResult.Yes Then
                If Not PreSave() Then
                    Revert = True
                    DgvNavigator.CancelNextMove = True
                End If
            End If
            If Revert Then
                For Each Responsible As CashItemResponsible In _CashItem.Responsibles.ToArray.Reverse
                    If Not _CashItemShadow.Responsibles.Any(Function(x) x.Responsible.ID = Responsible.Responsible.ID) Then
                        _CashItem.Responsibles.Remove(Responsible)
                    End If
                Next Responsible
                For Each ShadowResponsible As CashItemResponsible In _CashItemShadow.Responsibles
                    If Not _CashItem.Responsibles.Any(Function(x) x.Responsible.ID = ShadowResponsible.Responsible.ID) Then
                        _CashItem.Responsibles.Add(ShadowResponsible)
                    End If
                Next ShadowResponsible
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        If _CashForm.DgvCashItem.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _CashItem = _Cash.CashItems.Single(Function(x) x.Guid = _CashForm.DgvCashItem.SelectedRows(0).Cells("Guid").Value)
            _CashItemShadow = _CashItem.Clone()
            LoadForm()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Response As DialogResult
        Dim Revert As Boolean
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                Response = CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo)
                If Response = DialogResult.No Then
                    Revert = True
                ElseIf Response = DialogResult.Yes Then
                    If Not PreSave() Then
                        e.Cancel = True
                        Revert = True
                    End If
                End If
                If Revert Then
                    For Each Responsible As CashItemResponsible In _CashItem.Responsibles.ToArray.Reverse
                        If Not _CashItemShadow.Responsibles.Any(Function(x) x.Responsible.ID = Responsible.Responsible.ID) Then
                            _CashItem.Responsibles.Remove(Responsible)
                        End If
                    Next Responsible
                    For Each Responsible As CashItemResponsible In _CashItemShadow.Responsibles
                        If Not _CashItem.Responsibles.Any(Function(x) x.Responsible.ID = Responsible.Responsible.ID) Then
                            _CashItem.Responsibles.Add(Responsible)
                        End If
                    Next Responsible
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
        Dim ItemResponsible As CashItemResponsible
        Dim Responsibles As New List(Of CashItemResponsible)
        For Each ItemResponsible In _CashItem.Responsibles
            ItemResponsible = New CashItemResponsible()
            ItemResponsible.Responsible = New Person().Load(ItemResponsible.Responsible.ID, False)
            ItemResponsible.SetIsSaved(True)
            Responsibles.Add(ItemResponsible)
        Next ItemResponsible
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then
                    For Each ItemResponsible In _CashItem.Responsibles.ToArray.Reverse
                        If Not _CashItemShadow.Responsibles.Any(Function(x) x.Responsible.ID = ItemResponsible.Responsible.ID) Then
                            _CashItem.Responsibles.Remove(ItemResponsible)
                        End If
                    Next ItemResponsible
                    For Each ItemResponsible In _CashItemShadow.Responsibles
                        If Not _CashItem.Responsibles.Any(Function(x) x.Responsible.ID = ItemResponsible.Responsible.ID) Then
                            _CashItem.Responsibles.Add(ItemResponsible)
                        End If
                    Next ItemResponsible
                End If
            End If
        End If
        _CashItem = New CashItem()
        _CashItem.Responsibles = Responsibles
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CashForm.DgvCashItem.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _CashItem = _Cash.CashItems.Single(Function(x) x.Guid = _CashForm.DgvCashItem.SelectedRows(0).Cells("Guid").Value)
                _Cash.CashItems.Remove(_CashItem)
                _CashForm.DgvCashItem.Fill(_Cash.CashItems)
                _CashForm.DgvCashItemsLayout.Load()
                _CashForm.CalculateValues()
                _Deleting = True
                Dispose()
                _CashForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.CashItem, _CashItem.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub Rbt_CheckedChanged(sender As Object, e As EventArgs) Handles RbExpense.CheckedChanged, RbIncome.CheckedChanged
        Dim Radio As RadioButton = CType(sender, RadioButton)
        If _CategoryList IsNot Nothing Then
            If Radio.Equals(RbExpense) Then
                CbxCategory.DataSource = _CategoryList.Where(Function(x) x <> "REEMBOLSO").ToList()
            Else
                CbxCategory.DataSource = _CategoryList.Where(Function(x) x = "REEMBOLSO").ToList()
            End If
        End If
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtDescription.TextChanged,
                                                                         TxtDocumentNumber.TextChanged,
                                                                         DbxDocumentDate.TextChanged,
                                                                         DbxValue.TextChanged,
                                                                         CbxCategory.SelectedIndexChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub DgvResponsibles_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvResponsibles.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvResponsibles.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditCashItemResponsible.PerformClick()
        End If
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_CashItem.IsSaved, _CashForm.DgvCashItem.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _CashItem.Creation
        RbExpense.Checked = _CashItem.ItemType = CashItemType.Expense
        RbIncome.Checked = _CashItem.ItemType = CashItemType.Income
        If RbExpense.Checked Then
            CbxCategory.DataSource = _CategoryList.Where(Function(x) x <> "REEMBOLSO").ToList
        Else
            CbxCategory.DataSource = _CategoryList.Where(Function(x) x = "REEMBOLSO").ToList
        End If
        CbxCategory.SelectedIndex = CbxCategory.FindStringExact(EnumHelper.GetEnumDescription(_CashItem.ItemCategory))
        TxtDescription.Text = _CashItem.Description
        TxtDocumentNumber.Text = _CashItem.DocumentNumber
        DbxDocumentDate.Text = _CashItem.DocumentDate
        DbxValue.Text = _CashItem.Value
        If Not _CashItem.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        DgvResponsibles.Fill(_CashItem.Responsibles)
        BtnSave.Enabled = False
        TxtDescription.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtDescription.Text) Then
            EprValidation.SetError(LblDescription, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblDescription, ErrorIconAlignment.MiddleRight)
            TxtDescription.Select()
            Return False
        ElseIf Not IsDate(DbxDocumentDate.Text) Then
            EprValidation.SetError(LblDocumentDate, "Data inválida.")
            EprValidation.SetIconAlignment(LblDocumentDate, ErrorIconAlignment.MiddleRight)
            DbxDocumentDate.Select()
            Return False
        ElseIf DbxDocumentDate.Text > Today Then
            EprValidation.SetError(LblDocumentDate, "A data do documento não pode ser maior do que hoje.")
            EprValidation.SetIconAlignment(LblDocumentDate, ErrorIconAlignment.MiddleRight)
            DbxDocumentDate.Select()
            Return False
        ElseIf DbxValue.DecimalValue <= 0 Then
            EprValidation.SetError(LblValue, "O valor deve ser maior que zero.")
            EprValidation.SetIconAlignment(LblValue, ErrorIconAlignment.MiddleRight)
            DbxValue.Select()
            Return False
        ElseIf DbxValue.DecimalValue > 9999999999 Then
            EprValidation.SetError(LblValue, "O valor deve ser menor ou igual a 99.999.999,99.")
            EprValidation.SetIconAlignment(LblValue, ErrorIconAlignment.MiddleRight)
            DbxValue.Select()
            Return False
        ElseIf DgvResponsibles.Rows.Count = 0 Then
            EprValidation.SetError(TsResponsibles, "O lançamento deve ter pelo menos um responsável.")
            EprValidation.SetIconAlignment(TsResponsibles, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsResponsibles, -90)
            DgvResponsibles.Select()
            Return False
        End If
        Return True
    End Function

    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtDescription.Text = TxtDescription.Text.Trim.ToUnaccented()
        TxtDocumentNumber.Text = TxtDocumentNumber.Text.Trim.ToUnaccented()
        If IsValidFields() Then
            _Suggestions.Add(TxtDescription.Text)
            SaveSuggestions()
            If _CashItem.IsSaved Then
                _Cash.CashItems.Single(Function(x) x.Guid = _CashItem.Guid).ItemType = If(RbExpense.Checked, CashItemType.Expense, CashItemType.Income)
                _Cash.CashItems.Single(Function(x) x.Guid = _CashItem.Guid).ItemCategory = EnumHelper.GetEnumValue(Of CashItemCategory)(CbxCategory.Text)
                _Cash.CashItems.Single(Function(x) x.Guid = _CashItem.Guid).Description = TxtDescription.Text
                _Cash.CashItems.Single(Function(x) x.Guid = _CashItem.Guid).DocumentDate = DbxDocumentDate.Text
                _Cash.CashItems.Single(Function(x) x.Guid = _CashItem.Guid).DocumentNumber = TxtDocumentNumber.Text
                _Cash.CashItems.Single(Function(x) x.Guid = _CashItem.Guid).Value = DbxValue.DecimalValue
            Else
                _CashItem.ItemType = If(RbExpense.Checked, CashItemType.Expense, CashItemType.Income)
                _CashItem.ItemCategory = EnumHelper.GetEnumValue(Of CashItemCategory)(CbxCategory.Text)
                _CashItem.Description = TxtDescription.Text
                _CashItem.DocumentDate = DbxDocumentDate.Text
                _CashItem.DocumentNumber = TxtDocumentNumber.Text
                _CashItem.Value = DbxValue.DecimalValue
                _CashItem.SetIsSaved(True)
                _Cash.CashItems.Add(_CashItem)
            End If
            _CashForm.DgvCashItem.Fill(_Cash.CashItems)
            _CashForm.DgvCashItemsLayout.Load()
            BtnSave.Enabled = False
            BtnDelete.Enabled = True
            If Not _CashItem.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _CashForm.DgvCashItem.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _CashItem.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _CashForm.DgvCashItem.SelectedRows(0).Cells("Order").Value
            _CashForm.EprValidation.Clear()
            _CashForm.CalculateValues()
            _CashForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub BtnIncludeCashItemResponsible_Click(sender As Object, e As EventArgs) Handles BtnIncludeCashItemResponsible.Click
        Dim Form As New FrmCashItemResponsible(_CashItem, New CashItemResponsible(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditCashItemResponsible_Click(sender As Object, e As EventArgs) Handles BtnEditCashItemResponsible.Click
        Dim Form As FrmCashItemResponsible
        Dim Responsible As CashItemResponsible
        If DgvResponsibles.SelectedRows.Count = 1 Then
            Responsible = _CashItem.Responsibles.Single(Function(X) X.Guid = DgvResponsibles.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmCashItemResponsible(_CashItem, Responsible, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteCashItemResponsible_Click(sender As Object, e As EventArgs) Handles BtnDeleteCashItemResponsible.Click
        Dim Responsible As CashItemResponsible
        If DgvResponsibles.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Responsible = _CashItem.Responsibles.Single(Function(X) X.Guid = DgvResponsibles.SelectedRows(0).Cells("Guid").Value)
                _CashItem.Responsibles.Remove(Responsible)
                DgvResponsibles.Fill(_CashItem.Responsibles)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvResponsibles.SelectionChanged
        If DgvResponsibles.SelectedRows.Count = 0 Then
            BtnEditCashItemResponsible.Enabled = False
            BtnDeleteCashItemResponsible.Enabled = False
        Else
            BtnEditCashItemResponsible.Enabled = True
            BtnDeleteCashItemResponsible.Enabled = True
        End If
    End Sub
End Class