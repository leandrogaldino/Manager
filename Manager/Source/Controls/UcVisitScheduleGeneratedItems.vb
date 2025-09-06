Public Class UcVisitScheduleGeneratedItems
    Private _Evaluation As Lazy(Of Evaluation)
    Private _Schedule As Lazy(Of VisitSchedule)
    Private _EvaluationID As Long
    Private _ScheduleID As Long

    Public Event ValueChanged As EventHandler
    Public Event EvaluationClick As EventHandler
    Public Event VisitScheduleClick As EventHandler

    Public Property EvaluationID As Long
        Get
            Return _EvaluationID
        End Get
        Set(value As Long)
            If _EvaluationID <> value Then
                _EvaluationID = value
                OnValueChanged(Me)
            End If
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
            If _ScheduleID <> value Then
                _ScheduleID = value
                OnValueChanged(Me)
            End If
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
        Dim Evaluation As Evaluation = If(EvaluationID > 0, Me.Evaluation.Value, Nothing)
        OnEvaluationClick(Evaluation)
    End Sub
    Private Sub BtnSchedule_Click(sender As Object, e As EventArgs) Handles BtnSchedule.Click
        Dim Schedule As VisitSchedule = If(ScheduleID > 0, Me.Schedule.Value, Nothing)
        OnVisitScheduleClick(Evaluation)
    End Sub
    Private Sub OnValueChanged(s)
        RaiseEvent ValueChanged(s, EventArgs.Empty)
    End Sub
    Private Sub OnEvaluationClick(e)
        RaiseEvent EvaluationClick(e, EventArgs.Empty)
    End Sub
    Private Sub OnVisitScheduleClick(e)
        RaiseEvent VisitScheduleClick(If(ScheduleID > 0, Schedule.Value, Nothing), EventArgs.Empty)
    End Sub
End Class
