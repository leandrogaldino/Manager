Imports ControlLibrary

Public Class FrmEvaluationManagementPanelExport
    Private _Person As Person
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

    Private _DgvInDay As DataGridView
    Private _DgvToOverdue As DataGridView
    Private _DgvOverdue As DataGridView
    Private _DgvUnitOverdue As DataGridView
    Private _DgvNeverVisited As DataGridView
    Private _DgvTovisit As DataGridView
    Private _DgvTotal As DataGridView
    Public Sub New(InDay As DataGridView, ToOverdue As DataGridView, Overdue As DataGridView, UnitOverdue As DataGridView, NeverVisited As DataGridView, ToVisit As DataGridView, Total As DataGridView)
        InitializeComponent()
        _DgvInDay = InDay
        _DgvToOverdue = ToOverdue
        _DgvOverdue = Overdue
        _DgvUnitOverdue = UnitOverdue
        _DgvNeverVisited = NeverVisited
        _DgvTovisit = ToVisit
        _DgvTotal = Total
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnGenerate.Enabled = False
    End Sub
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim Result As ReportResult
        Dim ExportList As New List(Of ExportGrid.ExportGridInfo)
        If CbxInDay.Checked Then ExportList.Add(New ExportGrid.ExportGridInfo With {.Grid = _DgvInDay, .Title = "EM DIA"})
        If CbxToOverdue.Checked Then ExportList.Add(New ExportGrid.ExportGridInfo With {.Grid = _DgvToOverdue, .Title = "A VENCER"})
        If CbxOverdue.Checked Then ExportList.Add(New ExportGrid.ExportGridInfo With {.Grid = _DgvOverdue, .Title = "VENCIDO"})
        If CbxUnitOverdue.Checked Then ExportList.Add(New ExportGrid.ExportGridInfo With {.Grid = _DgvUnitOverdue, .Title = "UNIDADE VENCIDA"})
        If CbxNeverVisited.Checked Then ExportList.Add(New ExportGrid.ExportGridInfo With {.Grid = _DgvNeverVisited, .Title = "NUNCA VISITADO"})
        If CbxToVisit.Checked Then ExportList.Add(New ExportGrid.ExportGridInfo With {.Grid = _DgvTovisit, .Title = "A VISITAR"})
        If CbxTotal.Checked Then ExportList.Add(New ExportGrid.ExportGridInfo With {.Grid = _DgvTotal, .Title = "TODOS"})
        Try
            Cursor = Cursors.WaitCursor
            BtnGenerate.Enabled = False
            Result = ExportGrid.Export(ExportList.ToArray)
            DialogResult = DialogResult.OK
            FrmMain.OpenTab(New UcReport(Result), EnumHelper.GetEnumDescription(Routine.EvaluationExportManagementPanel))
        Catch ex As Exception
            CMessageBox.Show("ERRO EV018", "Ocorreu um erro exportar.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            BtnGenerate.Enabled = True
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CbxGreen_CheckedChanged(sender As Object, e As EventArgs) Handles CbxToOverdue.CheckedChanged, CbxOverdue.CheckedChanged, CbxToVisit.CheckedChanged, CbxNeverVisited.CheckedChanged, CbxInDay.CheckedChanged, CbxTotal.CheckedChanged, CbxUnitOverdue.CheckedChanged, CbxUnitOverdue.CheckedChanged
        If ControlHelper.GetAllControls(Me, True).OfType(Of CheckBox).All(Function(x) x.Checked = False) Then
            BtnGenerate.Enabled = False
        Else
            BtnGenerate.Enabled = True
        End If
    End Sub
End Class