
Public Class UcCallType
    Public Event CheckedChanged As EventHandler
    Private _SelectedType As CallType = CallType.None
    Private _Switching As Boolean
    Public Property SelectedType As CallType
        Get
            Return _SelectedType
        End Get
        Set(value As CallType)
            _Switching = True
            If value = CallType.Gathering Then RbtGathering.Checked = True
            If value = CallType.Contract Then RbtPreventive.Checked = True
            _SelectedType = value
            OnCheckedChanged()
            _Switching = False
        End Set
    End Property
    Private Sub Rbt_CheckedChanged(sender As Object, e As EventArgs) Handles RbtGathering.CheckedChanged, RbtPreventive.CheckedChanged, RbtContract.CheckedChanged, RbtCalled.CheckedChanged
        If _Switching Then Return
        _SelectedType = CallType.None
        If RbtGathering.Checked Then _SelectedType = CallType.Gathering
        If RbtPreventive.Checked Then _SelectedType = CallType.Contract
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class
