Imports System.ComponentModel

Public Class UcEvaluationSourceItem

    Public Event SelectionChanged(sender As Object, e As EventArgs)
    Private _UcSoldLost As UcEvaluationSoldLost
    Private Sub OnSelectionChanged()
        RaiseEvent SelectionChanged(Me, EventArgs.Empty)
    End Sub



    Private _IsSold As Boolean = False
    Private _IsLost As Boolean = False


    Public Sub New(Title As String, Item1 As String, item2 As String, IsSold As Boolean, IsLost As Boolean)
        InitializeComponent()
        LblTitle.Text = Title
        CbxItem1.Text = Item1
        CbxItem2.Text = item2
        _UcSoldLost = New UcEvaluationSoldLost
        CcSoldLost.DropDownControl = _UcSoldLost
    End Sub
    Public Sub New()
        InitializeComponent()
        _UcSoldLost = New UcEvaluationSoldLost
        CcSoldLost.DropDownControl = _UcSoldLost
    End Sub






    <Category("TileData")>
    <DefaultValue(False)>
    Public Property IsSold As Boolean
        Get
            Return _IsSold
        End Get
        Set(value As Boolean)
            _IsSold = value
            If value Then
                _IsLost = False
                BtnSoldLost.Text = "Troca: Vendido"
            Else
                If Not _IsLost Then
                    BtnSoldLost.Text = "Troca: N/A"
                End If
            End If
            ConfigureTile()
        End Set
    End Property

    <Category("TileData")>
    <DefaultValue(False)>
    Public Property IsLost As Boolean
        Get
            Return _IsLost
        End Get
        Set(value As Boolean)
            _IsLost = value
            If value Then
                _IsSold = False
                BtnSoldLost.Text = "Troca: Perdido"
            Else
                If Not _IsSold Then
                    BtnSoldLost.Text = "Troca: N/A"
                End If
            End If
            ConfigureTile()
        End Set
    End Property

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
    Private Sub ConfigureTile()

    End Sub
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
        OnSelectionChanged()
    End Sub
End Class
