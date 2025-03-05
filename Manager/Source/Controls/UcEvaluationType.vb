
Public Class UcEvaluationType
    Public Event CheckedChanged As EventHandler
    Private _SelectedType As EvaluationType = EvaluationType.None
    Private _Switching As Boolean
    Public Property SelectedType As EvaluationType
        Get
            Return _SelectedType
        End Get
        Set(value As EvaluationType)
            _Switching = True
            If value = EvaluationType.Gathering Then RbtGathering.Checked = True
            If value = EvaluationType.Execution Then RbtExecution.Checked = True
            _Switching = False
        End Set
    End Property
    Private Sub Rbt_CheckedChanged(sender As Object, e As EventArgs) Handles RbtGathering.CheckedChanged, RbtExecution.CheckedChanged
        If _Switching Then Return
        _SelectedType = EvaluationType.None
        If RbtGathering.Checked Then _SelectedType = EvaluationType.Gathering
        If RbtExecution.Checked Then _SelectedType = EvaluationType.Execution
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class
