Public Class UcEvaluationNeedProposal
    Public Event CheckedChanged As EventHandler
    Private _SelectedNeedProposal As EvaluationNeedProposal = EvaluationNeedProposal.None
    Private _Switching As Boolean
    Public Property SelectedNeedProposal As EvaluationNeedProposal
        Get
            Return _SelectedNeedProposal
        End Get
        Set(value As EvaluationNeedProposal)
            _Switching = True
            If value = EvaluationNeedProposal.Yes Then RbtYes.Checked = True
            If value = EvaluationNeedProposal.No Then RbtNo.Checked = True
            _SelectedNeedProposal = value
            OnCheckedChanged()
            _Switching = False
        End Set
    End Property
    Private Sub Rbt_CheckedChanged(sender As Object, e As EventArgs) Handles RbtYes.CheckedChanged, RbtNo.CheckedChanged
        If _Switching Then Return
        _SelectedNeedProposal = EvaluationNeedProposal.None
        If RbtYes.Checked Then _SelectedNeedProposal = EvaluationNeedProposal.Yes
        If RbtNo.Checked Then _SelectedNeedProposal = EvaluationNeedProposal.No
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class
