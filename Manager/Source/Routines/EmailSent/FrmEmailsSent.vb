Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmEmailsSent
    Private _Filter As EmailSentFilter
    Private _User As User
    Public Sub New()
        InitializeComponent()
        EnableControlDoubleBuffer(DgvData, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer1.SplitterDistance = 250
        SplitContainer2.Panel1Collapsed = True
        SplitContainer2.SplitterDistance = 250
        _Filter = New EmailSentFilter(DgvData, PgFilter)
        _Filter.Filter()
        _User = Locator.GetInstance(Of Session).User
        PgFilter.SelectedObject = _Filter
        DgvEmailSentLayout.Load()
        BtnExport.Visible = _User.CanAccess(Routine.ExportGrid)
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvEmailSentLayout.Load()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        _Filter.Filter()
        DgvEmailSentLayout.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = If(BtnFilter.Checked, False, True)
        SplitContainer1.SplitterDistance = 350
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dim Index As Integer
        If Not Control.ModifierKeys = Keys.Shift Then
            Index = FrmMain.TcWindows.SelectedIndex
            FrmMain.TcWindows.TabPages.Remove(FrmMain.TcWindows.SelectedTab)
            If Index > 0 Then
                FrmMain.TcWindows.SelectTab(Index - 1)
            End If
        Else
            For Each Page As TabPage In FrmMain.TcWindows.TabPages
                FrmMain.TcWindows.TabPages.Remove(Page)
            Next Page
        End If
    End Sub
    Private Sub BtnCloseFilter_Click(sender As Object, e As EventArgs) Handles BtnCloseFilter.Click
        SplitContainer1.Panel1Collapsed = True
        BtnFilter.Checked = False
    End Sub
    Private Sub BtnClean_Click(sender As Object, e As EventArgs) Handles BtnClean.Click
        _Filter.Clean()
        _Filter.Filter()
        PgFilter.Refresh()
        DgvEmailSentLayout.Load()
        LblStatus.Text = Nothing
        LblStatus.ForeColor = Color.Black
        LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
    End Sub
    Private Sub PgFilter_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PgFilter.PropertyValueChanged
        If _Filter.Filter() = True Then
            DgvEmailSentLayout.Load()
            LblStatus.Text = "Filtro Ativo"
            LblStatus.ForeColor = Color.DarkRed
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Bold)
        Else
            LblStatus.Text = String.Empty
            LblStatus.ForeColor = Color.Black
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
        End If
    End Sub
    Private Sub DgvData_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvData.DataSourceChanged
        If DgvData.Rows.Count > 0 Then
            LblCounter.Text = DgvData.Rows.Count & " registro" & If(DgvData.Rows.Count > 1, "s", Nothing)
            LblCounter.ForeColor = Color.DimGray
            LblCounter.Font = New Font(LblCounter.Font, FontStyle.Bold)
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub FrmMain_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If BtnFilter.Checked Then BtnFilter.PerformClick()
        If Parent.FindForm IsNot Nothing Then
            Height = Parent.FindForm.Height - 196
            Width = Parent.FindForm.Width - 24
        End If
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "E-Mails Enviados", .Grid = DgvData}})
        Dim FormReport As New FrmReport(Result)
        FrmMain.OpenTab(FormReport, GetEnumDescription(Routine.ExportGrid))
    End Sub
End Class