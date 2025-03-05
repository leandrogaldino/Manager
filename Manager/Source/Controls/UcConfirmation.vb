Public Class UcConfirmation
    Public Event CheckedChanged As EventHandler
    Private _SelectedAnswer As ConfirmationType = ConfirmationType.None
    Private _Switching As Boolean
    Public Property SelectedAnswer As ConfirmationType
        Get
            Return _SelectedAnswer
        End Get
        Set(value As ConfirmationType)
            _Switching = True
            If value = ConfirmationType.Yes Then RbtYes.Checked = True
            If value = ConfirmationType.No Then RbtNo.Checked = True
            _SelectedAnswer = value
            OnCheckedChanged()
            _Switching = False
        End Set
    End Property
    Private Sub Rbt_CheckedChanged(sender As Object, e As EventArgs) Handles RbtYes.CheckedChanged, RbtNo.CheckedChanged
        If _Switching Then Return
        _SelectedAnswer = ConfirmationType.None
        If RbtYes.Checked Then _SelectedAnswer = ConfirmationType.Yes
        If RbtNo.Checked Then _SelectedAnswer = ConfirmationType.No
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class
