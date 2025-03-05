Public Class UcEvaluationNeedProposal
    Public Event CheckedChanged As EventHandler
    Private _SelectedType As EvaluationNeedProposal = EvaluationNeedProposal.None
    Private _Switching As Boolean
    Public Property SelectedType As EvaluationNeedProposal
        Get
            Return _SelectedType
        End Get
        Set(value As EvaluationNeedProposal)
            _Switching = True
            If value = EvaluationNeedProposal.Yes Then RbtYes.Checked = True
            If value = EvaluationNeedProposal.No Then RbtNo.Checked = True
            _Switching = False
        End Set
    End Property
    Private Sub Rbt_CheckedChanged(sender As Object, e As EventArgs) Handles RbtYes.CheckedChanged, RbtNo.CheckedChanged
        If Not _Switching Then Return
        _SelectedType = EvaluationNeedProposal.None
        If RbtYes.Checked Then _SelectedType = EvaluationNeedProposal.Yes
        If RbtNo.Checked Then _SelectedType = EvaluationNeedProposal.No
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class
