Public Class UcVisitScheduleGeneratedItems
    Private _Evaluation As Lazy(Of Evaluation)
    Private _EvaluationID As Long
    Public Event ValueChanged As EventHandler
    Public Event EvaluationClick As EventHandler
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
    Public ReadOnly Property Evaluation As Lazy(Of Evaluation)
        Get
            Return _Evaluation
        End Get
    End Property
    Private Sub BtnEvaluation_Click(sender As Object, e As EventArgs) Handles BtnEvaluation.Click
        Dim Evaluation As Evaluation = If(EvaluationID > 0, Me.Evaluation.Value, Nothing)
        OnEvaluationClick(Evaluation)
    End Sub
    Private Sub OnValueChanged(s)
        RaiseEvent ValueChanged(s, EventArgs.Empty)
    End Sub
    Private Sub OnEvaluationClick(e)
        RaiseEvent EvaluationClick(e, EventArgs.Empty)
    End Sub
End Class
