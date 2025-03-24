Imports ControlLibrary

Public Class UcEvaluationCallTypeHasRepairNeedProposal
    Public Event ValueChanged As EventHandler
    Private _ManualChanging As Boolean
    Private Sub UcEvaluationCallTypeHasRepairNeedProposal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CbxVisitType.DataSource = EnumHelper.GetEnumDescriptions(Of CallType).OrderBy(Function(x) x).ToList()
        CbxHasRepair.DataSource = EnumHelper.GetEnumDescriptions(Of ConfirmationType).OrderBy(Function(x) x).ToList()
        CbxNeedProposal.DataSource = EnumHelper.GetEnumDescriptions(Of ConfirmationType).OrderBy(Function(x) x).ToList()
    End Sub
    Public Property VisitType As String
        Get
            Return CbxVisitType.SelectedValue
        End Get
        Set(value As String)
            _ManualChanging = True
            If CbxVisitType.SelectedValue <> value Then
                CbxVisitType.SelectedValue = value
                OnValueChanged(CbxVisitType)
            End If
            _ManualChanging = False
        End Set
    End Property
    Public Property HasRepair As String
        Get
            Return CbxHasRepair.SelectedValue
        End Get
        Set(value As String)
            _ManualChanging = True
            If CbxHasRepair.SelectedValue <> value Then
                CbxHasRepair.SelectedValue = value
                OnValueChanged(CbxHasRepair)
            End If
            _ManualChanging = False
        End Set
    End Property
    Public Property NeedProposal As String
        Get
            Return CbxNeedProposal.SelectedValue
        End Get
        Set(value As String)
            _ManualChanging = True
            If CbxNeedProposal.SelectedValue <> value Then
                CbxNeedProposal.SelectedValue = value
                OnValueChanged(CbxNeedProposal)
            End If
            _ManualChanging = False
        End Set
    End Property
    Private Sub OnValueChanged(s)
        RaiseEvent ValueChanged(s, EventArgs.Empty)
    End Sub

    Private Sub CbxVisitType_CbxNeedProposal_CbxHasRepair_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxVisitType.SelectedIndexChanged, CbxNeedProposal.SelectedIndexChanged, CbxHasRepair.SelectedIndexChanged
        If _ManualChanging Then Return
        OnValueChanged(sender)
    End Sub
End Class
