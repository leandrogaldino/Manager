Imports ControlLibrary

Public Class UcEvaluationCallTypeHasRepairNeedProposal
    Public Event ValueChanged As EventHandler
    Private _ManualChanging As Boolean
    Private Sub UcEvaluationCallTypeHasRepairNeedProposal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CbxVisitType.DataSource = EnumHelper.GetEnumDescriptions(Of CallType).OrderBy(Function(x) x).ToList()
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
            Return If(TbtnHasRepair.State = ToggleButton.ToggleButtonStates.ON, "SIM", "NAO")
        End Get
        Set(value As String)
            _ManualChanging = True
            Dim StateString As String = If(TbtnHasRepair.State = ToggleButton.ToggleButtonStates.ON, "SIM", "NAO")
            If StateString <> value Then
                TbtnHasRepair.State = If(value = "Sim", ToggleButton.ToggleButtonStates.ON, ToggleButton.ToggleButtonStates.OFF)
                OnValueChanged(TbtnHasRepair)
            End If
            _ManualChanging = False
        End Set
    End Property

    Private Sub OnValueChanged(s)
        RaiseEvent ValueChanged(s, EventArgs.Empty)
    End Sub

    Private Sub CbxVisitType_CbxNeedProposal_CbxHasRepair_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxVisitType.SelectedIndexChanged
        If _ManualChanging Then Return
        OnValueChanged(sender)
    End Sub
End Class
