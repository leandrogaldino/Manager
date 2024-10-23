Imports ControlLibrary

Public Class UcEvaluationSoldLost
    Private _Container As ControlContainer
    Public Sub New(Container As ControlContainer)
        InitializeComponent()
        _Container = Container
    End Sub

    Public ReadOnly Property IsSold As Boolean
        Get
            Return CbxSold.Checked
        End Get
    End Property
    Public ReadOnly Property IsLost As Boolean
        Get
            Return CbxLost.Checked
        End Get
    End Property
    Public ReadOnly Property IsNA As Boolean
        Get
            Return CbxNA.Checked
        End Get
    End Property

    Public ReadOnly Property AnyChecked As Boolean
        Get
            Return IsSold Or IsLost Or IsNA
        End Get
    End Property


    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles CbxSold.CheckedChanged, CbxLost.CheckedChanged, CbxNA.CheckedChanged
        Dim Control As CheckBox = CType(sender, CheckBox)
        If Control.Checked Then
            If Control Is CbxSold Then
                CbxLost.Checked = False
                CbxNA.Checked = False
            ElseIf Control Is CbxLost Then
                CbxSold.Checked = False
                CbxNA.Checked = False
            ElseIf Control Is CbxNA Then
                CbxLost.Checked = False
                CbxSold.Checked = False
            End If
        End If
        _Container.CloseDropDown()
    End Sub
End Class
