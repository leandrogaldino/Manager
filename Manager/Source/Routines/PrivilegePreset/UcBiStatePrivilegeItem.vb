Imports ControlLibrary
Public Class UcBiStatePrivilegeItem
    Public Event CheckedChanged As EventHandler
    Public Property Routine As Routine
        Get
            Return EnumHelper.GetEnumValue(Of Routine)(LblPrivilege.Text)
        End Get
        Set(value As Routine)
            LblPrivilege.Text = EnumHelper.GetEnumDescription(value)
            Dim Dependency = AttributeHelper.GetAttribute(Of RoutineDependencyAttribute)(value.GetType, value.ToString)
            If Dependency IsNot Nothing Then
                CbxTip.SetToolTip(CbxGrant, $"{CbxTip.GetToolTip(CbxGrant)} - Dependente de {EnumHelper.GetEnumDescription(Dependency.Dependency)}")
            End If
        End Set
    End Property
    Public Property Granted As Boolean
        Get
            Return CbxGrant.Checked
        End Get
        Set(value As Boolean)
            If CbxGrant.Checked <> value Then
                CbxGrant.Checked = value
                OnCheckedChanged()
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(Routine As Routine, Granted As Boolean)
        InitializeComponent()
        Me.Routine = Routine
        Me.Granted = Granted
        LblPrivilege.Text = EnumHelper.GetEnumDescription(Routine)
        CbxGrant.Checked = Granted
    End Sub

    Private Sub CbxGrant_CheckedChanged(sender As Object, e As EventArgs) Handles CbxGrant.CheckedChanged
        CbxGrant.Image = If(CbxGrant.Checked, My.Resources.Approve, My.Resources.Reject)
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class