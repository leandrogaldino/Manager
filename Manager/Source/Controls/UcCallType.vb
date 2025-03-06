Public Class UcCallType
    Public Event CheckedChanged As EventHandler
    Private _SelectedCallType As CallType = CallType.None
    Private _Switching As Boolean
    Public Property SelectedCallType As CallType
        Get
            Return _SelectedCallType
        End Get
        Set(value As CallType)
            _Switching = True
            If value = CallType.Gathering Then RbtGathering.Checked = True
            If value = CallType.Preventive Then RbtPreventive.Checked = True
            If value = CallType.Called Then RbtCalled.Checked = True
            If value = CallType.Contract Then RbtContract.Checked = True
            _SelectedCallType = value
            OnCheckedChanged()
            _Switching = False
        End Set
    End Property
    Private Sub Rbt_CheckedChanged(sender As Object, e As EventArgs) Handles RbtGathering.CheckedChanged, RbtPreventive.CheckedChanged, RbtContract.CheckedChanged, RbtCalled.CheckedChanged
        If _Switching Then Return
        _SelectedCallType = CallType.None
        If RbtGathering.Checked Then _SelectedCallType = CallType.Gathering
        If RbtPreventive.Checked Then _SelectedCallType = CallType.Preventive
        If RbtCalled.Checked Then _SelectedCallType = CallType.Called
        If RbtContract.Checked Then _SelectedCallType = CallType.Contract
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class
