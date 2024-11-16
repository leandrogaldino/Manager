Imports System.ComponentModel

Public Class UcEvaluationSourcePart

    Public Event ValidateRequired(sender As Object, e As EventArgs)
    Public ReadOnly Property UcSoldLost As UcEvaluationSoldLost
    Private Sub OnValidateRequired()
        RaiseEvent ValidateRequired(Me, EventArgs.Empty)
    End Sub

    Public Sub New(Title As String, Item1 As String, item2 As String)
        InitializeComponent()
        LblTitle.Text = Title
        CbxItem1.Text = Item1
        CbxItem2.Text = item2
        UcSoldLost = New UcEvaluationSoldLost(CcSoldLost)
        CcSoldLost.DropDownControl = UcSoldLost

    End Sub
    Public Sub New()
        InitializeComponent()
        UcSoldLost = New UcEvaluationSoldLost(CcSoldLost)
        CcSoldLost.DropDownControl = UcSoldLost
    End Sub



    <Browsable(False)>
    Public ReadOnly Property SelectedValue As String
        Get
            If CbxItem1.Checked Then
                Return CbxItem1.Text
            ElseIf CbxItem2.Checked Then
                Return CbxItem2.Text
            Else
                Return String.Empty
            End If
        End Get
    End Property

    <Category("TileData")>
    Public Property Title As String
        Get
            Return LblTitle.Text
        End Get
        Set(value As String)
            LblTitle.Text = value
        End Set
    End Property
    <Category("TileData")>
    Public Property Item1 As String
        Get
            Return CbxItem1.Text
        End Get
        Set(value As String)
            CbxItem1.Text = value
        End Set
    End Property
    <Category("TileData")>
    Public Property Item2 As String
        Get
            Return CbxItem2.Text
        End Get
        Set(value As String)
            CbxItem2.Text = value
        End Set
    End Property



    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles CbxItem1.CheckedChanged, CbxItem2.CheckedChanged
        Dim Control As CheckBox = CType(sender, CheckBox)
        Control.Image = If(Control.Checked, My.Resources.Approve, Nothing)
        If Control.Checked Then
            If Control Is CbxItem1 Then
                CbxItem2.Checked = False
            ElseIf Control Is CbxItem2 Then
                CbxItem1.Checked = False
            End If
        End If
        OnValidateRequired()
    End Sub

    Private Sub CcSoldLost_Closed(sender As Object) Handles CcSoldLost.Closed
        If UcSoldLost.IsSold Then BtnSoldLost.Text = "Troca: Vendido"
        If UcSoldLost.IsLost Then BtnSoldLost.Text = "Troca: Perdido"
        If UcSoldLost.IsNA Then BtnSoldLost.Text = "Troca: N/A"
        If Not UcSoldLost.AnyChecked Then BtnSoldLost.Text = "Troca?"
        OnValidateRequired()
    End Sub
End Class
