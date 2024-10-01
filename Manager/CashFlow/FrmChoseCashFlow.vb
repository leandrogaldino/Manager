Imports ControlLibrary
Public Class FrmChoseCashFlow
    Public Sub New(CashFlows As List(Of CashFlow))
        InitializeComponent()
        Try
            DgvCashFlow.DataSource = CashFlows
            DgvCashFlow.Columns.Cast(Of DataGridViewColumn).Where(Function(x) x.Name <> "Name").ToList().ForEach(Sub(y) y.Visible = False)
            DgvCashFlow.Columns("Name").HeaderText = "Nome"
            DgvCashFlow.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
            CMessageBox.Show("ERRO CF007", "Ocorreu um erro ao efetuar o login.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
    End Sub
    Private Sub DgvCashFlow_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCashFlow.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEnter.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub DgvCashFlow_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCashFlow.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCashFlow.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEnter.PerformClick()
        End If
    End Sub
End Class