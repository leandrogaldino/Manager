Imports CoreSuite.Controls
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports ManagerCore
Public Class FrmParameters
    Private ReadOnly _Preferences As PreferencesModel
    Private ReadOnly _PreferencesService As PreferencesService
    Private ReadOnly _Resizer As FluidResizer
    Private Const EvaluationHeight = 380
    Private Const UserHeight = 160
    Private Const ReleaseHeight = 190
    Private Const CleanHeight = 190
    Private _Loading As Boolean
    Public Sub New()
        InitializeComponent()
        _Preferences = Locator.GetInstance(Of SessionModel).Preferences
        If _Preferences Is Nothing Then _Preferences = New PreferencesModel()
        _PreferencesService = Locator.GetInstance(Of PreferencesService)
        _Resizer = New FluidResizer(Me)
        Height = EvaluationHeight
        FillFormWithModel()
    End Sub
    Private Sub FillFormWithModel()
        _Loading = True
        TbrCleanInterval.Value = _Preferences.Parameters.Clean.Interval
        DbxEvaluationDaysBeforeMaintenanceAlert.Text = _Preferences.Parameters.Evaluation.DaysBeforeMaintenanceAlert
        DbxEvaluationDaysBeforeVisitAlert.Text = _Preferences.Parameters.Evaluation.DaysBeforeVisitAlert
        DbxEvaluationMonthsBeforeRecordDeletion.Text = _Preferences.Parameters.Evaluation.MonthsBeforeRecordDeletion
        TxtFooterMaintenancePlan.Text = _Preferences.Parameters.Evaluation.FooterMaintenancePlan
        TbrReleaseRegister.Value = _Preferences.Parameters.Release.ReleaseBlockedRegisterInterval
        TxtUserDefaultPassword.Text = _Preferences.Parameters.User.DefaultPassword
        _Loading = False
    End Sub

    Private Sub FillModelWithForm()
        _Preferences.Parameters.Clean.Interval = TbrCleanInterval.Value
        _Preferences.Parameters.Evaluation.DaysBeforeMaintenanceAlert = DbxEvaluationDaysBeforeMaintenanceAlert.Text
        _Preferences.Parameters.Evaluation.DaysBeforeVisitAlert = DbxEvaluationDaysBeforeVisitAlert.Text
        _Preferences.Parameters.Evaluation.MonthsBeforeRecordDeletion = DbxEvaluationMonthsBeforeRecordDeletion.Text
        _Preferences.Parameters.Evaluation.FooterMaintenancePlan = TxtFooterMaintenancePlan.Text
        _Preferences.Parameters.Release.ReleaseBlockedRegisterInterval = TbrReleaseRegister.Value
        _Preferences.Parameters.Release.RefreshBlockedRegistryInterval = TbrReleaseRegister.Value - 1
        _Preferences.Parameters.User.DefaultPassword = TxtUserDefaultPassword.Text
    End Sub

    Private Sub TbrCleanInterval_ValueChanged(sender As Object, e As EventArgs) Handles TbrCleanInterval.ValueChanged
        If Not _Loading Then BtnSave.Enabled = True
        Dim Value As Integer = TbrCleanInterval.Value
        LblCleanInterval.Text = $"Executar a limpeza a cada {Value} dia{If(Value > 1, "s", String.Empty)}"
    End Sub

    Private Sub DbxEvaluationDaysBeforeMaintenanceAlert_TextChanged(sender As Object, e As EventArgs) Handles DbxEvaluationDaysBeforeMaintenanceAlert.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub DbxEvaluationDaysBeforeVisitAlert_TextChanged(sender As Object, e As EventArgs) Handles DbxEvaluationDaysBeforeVisitAlert.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub DbxEvaluationMonthsBeforeRecordDeletion_TextChanged(sender As Object, e As EventArgs) Handles DbxEvaluationMonthsBeforeRecordDeletion.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub TbrReleaseRegister_ValueChanged(sender As Object, e As EventArgs) Handles TbrReleaseRegister.ValueChanged
        If Not _Loading Then BtnSave.Enabled = True
        Dim Value As Integer = TbrReleaseRegister.Value
        LblReleaseRegister.Text = $"Liberar registros não atualizados a mais de {Value} minuto{If(Value > 1, "s", String.Empty)}"
    End Sub

    Private Sub TxtUserDefaultPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtUserDefaultPassword.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtFooterMaintenancePlan_TextChanged(sender As Object, e As EventArgs) Handles TxtFooterMaintenancePlan.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub DbxEvaluationDaysBeforeMaintenanceAlert_Leave(sender As Object, e As EventArgs) Handles DbxEvaluationDaysBeforeMaintenanceAlert.Leave
        If DbxEvaluationDaysBeforeMaintenanceAlert.DecimalValue < 0 Then
            DbxEvaluationDaysBeforeMaintenanceAlert.Text = 0
        End If
    End Sub

    Private Sub DbxEvaluationDaysBeforeVisitAlert_Leave(sender As Object, e As EventArgs) Handles DbxEvaluationDaysBeforeVisitAlert.Leave
        If DbxEvaluationDaysBeforeVisitAlert.DecimalValue < 0 Then
            DbxEvaluationDaysBeforeVisitAlert.Text = 0
        End If
    End Sub

    Private Sub DbxEvaluationMonthsBeforeRecordDeletion_Leave(sender As Object, e As EventArgs) Handles DbxEvaluationMonthsBeforeRecordDeletion.Leave
        If DbxEvaluationMonthsBeforeRecordDeletion.DecimalValue < 0 Then
            DbxEvaluationMonthsBeforeRecordDeletion.Text = 0
        End If
    End Sub

    Private Sub TcParameters_Selected(sender As Object, e As TabControlEventArgs) Handles TcParameters.Selected
        Dim SelectedTab As TabPage = e.TabPage
        If SelectedTab Is TabEvaluation Then _Resizer.SetSize(New Size() With {.Width = Me.Width, .Height = EvaluationHeight})
        If SelectedTab Is TabUser Then _Resizer.SetSize(New Size() With {.Width = Me.Width, .Height = UserHeight})
        If SelectedTab Is TabRelease Then _Resizer.SetSize(New Size() With {.Width = Me.Width, .Height = ReleaseHeight})
        If SelectedTab Is TabClean Then _Resizer.SetSize(New Size() With {.Width = Me.Width, .Height = CleanHeight})
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            Cursor = Cursors.WaitCursor
            FillModelWithForm()
            ManagerCore.Util.AsyncLock(Function() _PreferencesService.SaveAsync(_Preferences))
            DialogResult = DialogResult.OK
        Catch ex As Exception
            CMessageBox.Show("Ocorreu um erro ao salvar.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class