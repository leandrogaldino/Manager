Imports ControlLibrary
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.ComponentModel
Imports System.Xml

Public Class FrmEvaluationSettings
    Private _ViewModel As EvaluationSettingsViewModel

    Public Sub New()
        InitializeComponent()
        _ViewModel = New EvaluationSettingsViewModel()
        InitializeBindings()
        AddHandler _ViewModel.PropertyChanged, AddressOf OnViewModelPropertychanged
    End Sub

    Private Function IsValidFields() As Boolean
        If DbxEvaluationDaysToAlertMaintenance.DecimalValue < 1 Then
            EprValidation.SetError(LblEvaluationDaysToAlertMaintenance, "Informe um valor maior que 0")
            EprValidation.SetIconAlignment(LblEvaluationDaysToAlertMaintenance, ErrorIconAlignment.MiddleRight)
            DbxEvaluationDaysToAlertMaintenance.Select()
            Return False
        ElseIf DbxEvaluationDaysToAlertVisit.DecimalValue < 1 Then
            EprValidation.SetError(LblEvaluationDaysToAlertVisit, "Informe um valor maior que 0")
            EprValidation.SetIconAlignment(LblEvaluationDaysToAlertVisit, ErrorIconAlignment.MiddleRight)
            DbxEvaluationDaysToAlertVisit.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub OnViewModelPropertychanged(sender As Object, e As PropertyChangedEventArgs)
        EprValidation.Clear()
        BtnSave.Enabled = True
    End Sub
    Private Sub InitializeBindings()

        Dim Binding As Binding
        Binding = New Binding("Text", _ViewModel, "AlertMaintenance", False, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler Binding.Format, Sub(sender, e)
                                       If TypeOf e.Value Is String Then
                                           If (String.IsNullOrEmpty(e.Value)) Then
                                               e.Value = 0
                                           End If
                                       End If
                                   End Sub
        AddHandler Binding.Parse, Sub(sender, e)
                                      If TypeOf e.Value Is String Then
                                          If e.Value = "" Then
                                              e.Value = 0
                                          End If
                                      End If
                                  End Sub
        DbxEvaluationDaysToAlertMaintenance.DataBindings.Add(Binding)


        Binding = New Binding("Text", _ViewModel, "AlertVisit", False, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler Binding.Format, Sub(sender, e)
                                       If TypeOf e.Value Is String Then
                                           If (String.IsNullOrEmpty(e.Value)) Then
                                               e.Value = 0
                                           End If
                                       End If
                                   End Sub
        AddHandler Binding.Parse, Sub(sender, e)
                                      If TypeOf e.Value Is String Then
                                          If e.Value = "" Then
                                              e.Value = 0
                                          End If
                                      End If
                                  End Sub
        DbxEvaluationDaysToAlertVisit.DataBindings.Add(Binding)


    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Result As Boolean
        Cursor = Cursors.WaitCursor
        If IsValidFields() Then
            Result = _ViewModel.Save()
        End If
        Cursor = Cursors.Default
        BtnSave.Enabled = Not Result
    End Sub

    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim IsValid As Boolean
        Dim Result As Boolean
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                IsValid = IsValidFields()
                If IsValid Then
                    Result = _ViewModel.Save()
                End If

                If Not IsValid Or Not Result Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
End Class