Imports ControlLibrary
Imports ControlLibrary.Extensions

Public Class FrmEmailImportContact
    Private _User As User
    Public Sub New()
        InitializeComponent()
        _User = Locator.GetInstance(Of Session).User
    End Sub
    Private Sub QbxPerson_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPerson.FreezedPrimaryKeyChanged
        BtnView.Visible = QbxPerson.IsFreezed And _User.CanWrite(Routine.Person)
        BtnImport.Enabled = QbxPerson.IsFreezed
        DgvEmail.Columns.Clear()
        FillDataGridView(New Person().Load(QbxPerson.FreezedPrimaryKey, False))
    End Sub
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxPerson_Enter(sender As Object, e As EventArgs) Handles QbxPerson.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxPerson.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNew.Visible = _User.CanWrite(Routine.Person)
        BtnFilter.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxPerson_Leave(sender As Object, e As EventArgs) Handles QbxPerson.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Manufacturer As Person
        Manufacturer = New Person
        Using Form As New FrmPerson(Manufacturer)
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Manufacturer.ID > 0 Then
            QbxPerson.Freeze(Manufacturer.ID)
        End If
        QbxPerson.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Using Form As New FrmPerson(New Person().Load(QbxPerson.FreezedPrimaryKey, True))
            Form.ShowDialog()
        End Using
        QbxPerson.Freeze(QbxPerson.FreezedPrimaryKey)
        QbxPerson.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New PersonFilter(), QbxPerson) With {.Text = "Filtro de Pessoas"}
            Form.ShowDialog()
        End Using
        QbxPerson.Select()
    End Sub
    Private Sub FillDataGridView(Person As Person)
        Dim XColumn As DataGridViewCheckBoxColumn
        Person.Contacts.Where(Function(x) String.IsNullOrEmpty(x.Email)).ToList.ForEach(Sub(y) Person.Contacts.Remove(y))
        DgvEmail.Fill(Person.Contacts)
        For Each Column As DataGridViewColumn In DgvEmail.Columns
            Column.ReadOnly = True
        Next Column
        XColumn = New DataGridViewCheckBoxColumn With {.Name = "X", .HeaderText = "X".PadRight(3, " ")}
        XColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        XColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        XColumn.DisplayIndex = 0
        DgvEmail.Columns.Add(XColumn)
        DgvEmail.Columns("Order").Visible = False
        DgvEmail.Columns("ID").Visible = False
        DgvEmail.Columns("Creation").Visible = False
        DgvEmail.Columns("IsMainContact").Visible = False
        DgvEmail.Columns("JobTitle").Visible = False
        DgvEmail.Columns("Phone").Visible = False
        DgvEmail.Columns("Name").HeaderText = "Nome"
        DgvEmail.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEmail.Columns("Guid").Visible = False
        DgvEmail.Columns("Routine").Visible = False
        DgvEmail.Columns("IsSaved").Visible = False
        DgvEmail.Columns("User").Visible = False
        DgvEmail.Columns("Email").HeaderText = "E-Mail"
        DgvEmail.Columns("Email").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim Emails As New List(Of String)
        For Each Row As DataGridViewRow In DgvEmail.Rows
            If Row.Cells("X").Value = True Then
                Emails.Add(Row.Cells("Email").Value)
            End If
        Next Row
        Tag = Emails
        DialogResult = DialogResult.OK
    End Sub
    Private Sub DgvEmail_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvEmail.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvEmail.HitTest(e.X, e.Y)
        Dim Cell As DataGridViewCheckBoxCell
        Dim CellValue As Boolean
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            If ClickPlace.ColumnIndex <> DgvEmail.SelectedRows(0).Cells("X").ColumnIndex Then
                Cell = DgvEmail.SelectedRows(0).Cells("X")
                If Cell.IsInEditMode Then Exit Sub
                CellValue = If(Cell.Value, False, True)
                Cell.Value = CellValue
                Cell.EditingCellFormattedValue = CellValue
            End If
        End If
        DgvEmail.RefreshEdit()
    End Sub
    Private Sub DgvEmail_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvEmail.ColumnHeaderMouseClick
        Dim Index As Integer = DgvEmail.SelectedRows(0).Cells("X").ColumnIndex
        If e.ColumnIndex = Index Then
            If DgvEmail.Rows.Cast(Of DataGridViewRow).All(Function(x) x.Cells(Index).Value = True) Then
                For Each Row As DataGridViewRow In DgvEmail.Rows
                    Row.Cells(Index).Value = False
                Next Row
            Else
                For Each Row As DataGridViewRow In DgvEmail.Rows
                    Row.Cells(Index).Value = True
                Next Row
            End If
        End If
        DgvEmail.RefreshEdit()
    End Sub
End Class