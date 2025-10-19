Imports ControlLibrary

Public Class UcEvaluationCallTypeHasRepairNeedProposal
    Public Event ValueChanged As EventHandler
    Private _AutoChanging As Boolean
    Private _ManualChanging As Boolean
    Public Sub New()
        InitializeComponent()
        CbxCallType.DataSource = EnumHelper.GetEnumDescriptions(Of CallType).OrderBy(Function(x) x).ToList()
    End Sub
    Public Property CallType As CallType
        Get
            Return EnumHelper.GetEnumValue(Of CallType)(CbxCallType.SelectedValue)
        End Get
        Set(value As CallType)
            _AutoChanging = True
            If CallType <> value Then
                CbxCallType.SelectedItem = EnumHelper.GetEnumDescription(value)
                OnValueChanged(CbxCallType)
            End If
            _AutoChanging = False
        End Set
    End Property
    Public Property HasRepair As ConfirmationType
        Get
            If CbxHasRepairYes.Checked Then Return ConfirmationType.Yes
            If CbxHasRepairNo.Checked Then Return ConfirmationType.No
            Return ConfirmationType.None
        End Get
        Set(value As ConfirmationType)
            _AutoChanging = True
            If HasRepair <> value Then
                If value = ConfirmationType.Yes Then CbxHasRepairYes.Checked = True : CbxHasRepairNo.Checked = False
                If value = ConfirmationType.No Then CbxHasRepairNo.Checked = True : CbxHasRepairYes.Checked = False
                If value = ConfirmationType.None Then CbxHasRepairNo.Checked = False : CbxHasRepairYes.Checked = False
                OnValueChanged(Me)
            End If
            _AutoChanging = False
        End Set
    End Property
    Public Property NeedProposal As ConfirmationType
        Get
            If CbxNeedProposalYes.Checked Then Return ConfirmationType.Yes
            If CbxNeedProposalNo.Checked Then Return ConfirmationType.No
            Return ConfirmationType.None
        End Get
        Set(value As ConfirmationType)
            _AutoChanging = True
            If NeedProposal <> value Then
                If value = ConfirmationType.Yes Then CbxNeedProposalYes.Checked = True : CbxNeedProposalNo.Checked = False
                If value = ConfirmationType.No Then CbxNeedProposalNo.Checked = True : CbxNeedProposalYes.Checked = False
                If value = ConfirmationType.None Then CbxNeedProposalNo.Checked = False : CbxNeedProposalYes.Checked = False
                OnValueChanged(Me)
            End If
            _AutoChanging = False
        End Set
    End Property
    Private Sub OnValueChanged(s)
        RaiseEvent ValueChanged(s, EventArgs.Empty)
    End Sub

    Private Sub CbxCallType_CbxNeedProposal_CbxHasRepair_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxCallType.SelectedIndexChanged
        If _AutoChanging Then Return
        OnValueChanged(sender)
    End Sub

    Private Sub CbxHasRepairYes_CheckedChanged(sender As Object, e As EventArgs) Handles CbxHasRepairYes.CheckedChanged
        If _ManualChanging Then Return
        _ManualChanging = True
        If CbxHasRepairYes.Checked Then
            CbxHasRepairNo.Checked = False
        ElseIf Not CbxHasRepairNo.Checked Then
            CbxHasRepairNo.Checked = False
        End If
        OnValueChanged(sender)
        _ManualChanging = False
    End Sub

    Private Sub CbxHasRepairNo_CheckedChanged(sender As Object, e As EventArgs) Handles CbxHasRepairNo.CheckedChanged
        If _ManualChanging Then Return
        _ManualChanging = True
        If CbxHasRepairNo.Checked Then
            CbxHasRepairYes.Checked = False
        ElseIf Not CbxHasRepairYes.Checked Then
            CbxHasRepairYes.Checked = False
        End If
        OnValueChanged(sender)
        _ManualChanging = False
    End Sub

    Private Sub CbxNeedProposalYes_CheckedChanged(sender As Object, e As EventArgs) Handles CbxNeedProposalYes.CheckedChanged
        If _ManualChanging Then Return
        _ManualChanging = True
        If CbxNeedProposalYes.Checked Then
            CbxNeedProposalNo.Checked = False
        ElseIf Not CbxNeedProposalNo.Checked Then
            CbxNeedProposalNo.Checked = False
        End If
        OnValueChanged(sender)
        _ManualChanging = False
    End Sub

    Private Sub CbxNeedProposalNo_CheckedChanged(sender As Object, e As EventArgs) Handles CbxNeedProposalNo.CheckedChanged
        If _ManualChanging Then Return
        _ManualChanging = True
        If CbxNeedProposalNo.Checked Then
            CbxNeedProposalYes.Checked = False
        ElseIf Not CbxNeedProposalYes.Checked Then
            CbxNeedProposalYes.Checked = False
        End If
        OnValueChanged(sender)
        _ManualChanging = False
    End Sub
End Class
