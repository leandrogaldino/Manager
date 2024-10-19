Imports System.ComponentModel

Public Class UcEvaluationSourceTile
    Private _IsHeader As Boolean = False
    Public Sub New(Title As String, Item1 As String, item2 As String, Optional IsTitle As Boolean = False)
        InitializeComponent()
        LblTitle.Text = Title
        CbxItem1.Text = Item1
        CbxItem2.Text = item2
        NoName()
    End Sub
    Public Sub New()
        InitializeComponent()
        NoName()
    End Sub
    <Category("TileData")>
    <DefaultValue(False)>
    Public Property IsHeader As Boolean
        Get
            Return _IsHeader
        End Get
        Set(value As Boolean)
            _IsHeader = value
            NoName()
        End Set
    End Property
    <Browsable(False)>
    Public ReadOnly Property CheckedValue As String
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
    Private Sub NoName()
        If IsHeader Then
            LblTitle.Font = New Font(LblTitle.Font, FontStyle.Bold)
            CbxItem1.Font = New Font(CbxItem1.Font, FontStyle.Bold)
            CbxItem2.Font = New Font(CbxItem2.Font, FontStyle.Bold)
        Else
            LblTitle.Font = New Font(LblTitle.Font, FontStyle.Regular)
            CbxItem1.Font = New Font(CbxItem1.Font, FontStyle.Regular)
            CbxItem2.Font = New Font(CbxItem2.Font, FontStyle.Regular)
        End If
        Dim Top As Single = If(_IsHeader, 1, 0)
        PnTitle.Padding = New Padding(1, Top, 1, 1)
        PnItem1.Padding = New Padding(0, Top, 1, 1)
        PnItem2.Padding = New Padding(0, Top, 1, 1)
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
    End Sub
End Class
