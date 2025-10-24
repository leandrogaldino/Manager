Imports ControlLibrary
Imports MySql.Data.MySqlClient
Public Class FrmLog
    Private _Routine As Long
    Private _Registry As Long
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
    Public Sub New(Routine As Routine, Registry As Integer)
        InitializeComponent()
        _Routine = Routine
        _Registry = Registry
        Try
            LoadLog()
        Catch ex As Exception
            CMessageBox.Show("ERRO LG001", "Ocorreu um erro ao retornar o histórico do registo.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dispose()
    End Sub
    Private Sub LoadLog()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Table As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Com As New MySqlCommand(My.Resources.LogSelect, Con)
                Com.Parameters.AddWithValue("@routineid", _Routine)
                Com.Parameters.AddWithValue("@registryid", _Registry)
                Using Adp As New MySqlDataAdapter(Com)
                    Adp.Fill(Table)
                    DgvLog.DataSource = Table
                    DgvLog.Columns("id").Visible = False
                End Using
            End Using
        End Using
    End Sub
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult
        Try
            Cursor = Cursors.WaitCursor
            BtnExport.Enabled = False
            Result = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "Histórico", .Grid = DgvLog}})
            DialogResult = DialogResult.OK
            FrmMain.OpenTab(New UcReport(Result), "Grade Exportada")
            CMessageBox.Show("O Relátório foi gerado na tela inicial.", CMessageBoxType.Information)
        Catch ex As Exception
            CMessageBox.Show("ERRO LG002", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class