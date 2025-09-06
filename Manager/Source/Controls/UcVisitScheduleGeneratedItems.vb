Public Class UcVisitScheduleGeneratedItems
    Private _Evaluation As Lazy(Of Evaluation)
    Private _Schedule As Lazy(Of VisitSchedule)
    Private _EvaluationID As Long
    Private _ScheduleID As Long
    Public Property EvaluationID As Long
        Get
            Return _EvaluationID
        End Get
        Set(value As Long)
            _EvaluationID = value
            If value > 0 Then
                BtnEvaluation.Enabled = True
                _Evaluation = New Lazy(Of Evaluation)(Function() New Evaluation().Load(_EvaluationID, True))
            Else
                BtnEvaluation.Enabled = False
                _Evaluation = Nothing
            End If
        End Set
    End Property
    Public Property ScheduleID As Long
        Get
            Return _ScheduleID
        End Get
        Set(value As Long)
            _ScheduleID = value
            If value > 0 Then
                BtnSchedule.Enabled = True
                _Schedule = New Lazy(Of VisitSchedule)(Function() New VisitSchedule().Load(_EvaluationID, True))
            Else
                BtnSchedule.Enabled = False
                _Schedule = Nothing
            End If
        End Set
    End Property
    Public ReadOnly Property Evaluation As Lazy(Of Evaluation)
        Get
            Return _Evaluation
        End Get
    End Property
    Public ReadOnly Property Schedule As Lazy(Of VisitSchedule)
        Get
            Return _Schedule
        End Get
    End Property
    Private Sub BtnEvaluation_Click(sender As Object, e As EventArgs) Handles BtnEvaluation.Click
        Dim FrmEvaluation As New FrmEvaluation(_Evaluation.Value)
        FrmEvaluation.ShowDialog()
    End Sub
    Private Sub BtnSchedule_Click(sender As Object, e As EventArgs) Handles BtnSchedule.Click
        Dim FrmSchedule As New FrmVisitSchedule(_Schedule.Value)
        FrmSchedule.ShowDialog()
    End Sub
End Class
