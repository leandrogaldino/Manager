Imports ControlLibrary
Public Class FrmFilter
    Private _Filter As Object
    Private _QueriedTextBox As QueriedBox
    Private Const _MouseButtonDown As Long = &HA1
    Private Const _MouseButtonUp As Long = &HA0
    Private Const _CloseButton As Long = 20
    Public Sub New(Filter As Object, QueriedTextBox As QueriedBox)
        InitializeComponent()
        Utility.EnableDataGridViewDoubleBuffer(DgvData, True)
        _Filter = Filter
        _QueriedTextBox = QueriedTextBox
        _Filter.DataGridView = DgvData
        _Filter.Filter()
        PgFilter.SelectedObject = _Filter
        DgvData.Columns.Cast(Of DataGridViewColumn).Where(Function(x) x.HeaderText = "Status").ToList.ForEach(Sub(y) y.Visible = False)
        DgvData.Select()
    End Sub
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
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter And DgvData.SelectedRows.Count = 1 Then
            BtnImport.PerformClick()
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
        End If
    End Sub
    Private Sub BtnClean_Click(sender As Object, e As EventArgs) Handles BtnClean.Click
        _Filter.Clean()
        PgFilter.Refresh()
        _Filter.Filter()
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        _QueriedTextBox.Freeze(DgvData.SelectedRows(0).Cells("ID").Value)
        Dispose()
    End Sub
    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvData.SelectionChanged
        BtnImport.Enabled = If(DgvData.SelectedRows.Count = 1, True, False)
    End Sub
    Private Sub DgvData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvData.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvData.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnImport.PerformClick()
        End If
    End Sub
    Private Sub DgvData_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvData.DataSourceChanged
        If DgvData.Rows.Count > 0 Then
            LblCounter.Text = DgvData.Rows.Count & " registro" & If(DgvData.Rows.Count > 1, "s", Nothing)
            LblCounter.ForeColor = Color.DimGray
            LblCounter.Font = New Font(LblCounter.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub PgFilter_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PgFilter.PropertyValueChanged
        _Filter.Filter()
    End Sub
End Class