Imports System.ComponentModel

Public Class UcEvaluationSourceTile

    Public Event SelectionChanged(sender As Object, e As EventArgs)

    Private Sub OnSelectionChanged()
        RaiseEvent SelectionChanged(Me, EventArgs.Empty)
    End Sub


    Private _IsHeader As Boolean = False
    Private _IsSold As Boolean = False
    Private _IsLost As Boolean = False


    Public Sub New(Title As String, Item1 As String, item2 As String, IsSold As Boolean, IsLost As Boolean, Optional IsHeader As Boolean = False)
        InitializeComponent()
        LblTitle.Text = Title
        CbxItem1.Text = Item1
        CbxItem2.Text = item2
        _IsHeader = IsHeader
        ConfigureTile()
    End Sub
    Public Sub New()
        InitializeComponent()
        ConfigureTile()
    End Sub
    <Category("TileData")>
    <DefaultValue(False)>
    Public Property IsHeader As Boolean
        Get
            Return _IsHeader
        End Get
        Set(value As Boolean)
            _IsHeader = value
            ConfigureTile()
        End Set
    End Property



    <Category("TileData")>
    <DefaultValue(False)>
    Public Property IsSold As Boolean
        Get
            Return _IsSold
        End Get
        Set(value As Boolean)
            _IsSold = value
            If value Then
                LblSoldLost.Text = "Vendido"
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
                LblSoldLost.Text = "Perdido"
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
        Dim Top As Single
        If IsHeader Then
            LblTitle.Font = New Font(LblTitle.Font, FontStyle.Bold)
            CbxItem1.Font = New Font(CbxItem1.Font, FontStyle.Bold)
            CbxItem1.AutoCheck = False
            CbxItem1.FlatAppearance.MouseOverBackColor = Color.White
            CbxItem1.FlatAppearance.CheckedBackColor = Color.White
            CbxItem1.FlatAppearance.MouseDownBackColor = Color.White
            CbxItem1.Cursor = Cursors.Default
            CbxItem2.Font = New Font(CbxItem2.Font, FontStyle.Bold)
            CbxItem2.AutoCheck = False
            CbxItem2.FlatAppearance.MouseOverBackColor = Color.White
            CbxItem2.FlatAppearance.CheckedBackColor = Color.White
            CbxItem2.FlatAppearance.MouseDownBackColor = Color.White
            CbxItem2.Cursor = Cursors.Default
            Top = 1
        Else
            LblTitle.Font = New Font(LblTitle.Font, FontStyle.Regular)
            CbxItem1.Font = New Font(CbxItem1.Font, FontStyle.Regular)
            CbxItem2.Font = New Font(CbxItem2.Font, FontStyle.Regular)
            Top = 0
        End If
        PnTitle.Padding = New Padding(1, Top, 1, 1)
        PnItem1.Padding = New Padding(0, Top, 1, 1)
        PnItem2.Padding = New Padding(0, Top, 1, 1)
        PnSoldLost.Padding = New Padding(0, 0, 1, 1)
        If IsSold Or IsLost Then
            TlpContainer.RowCount = 2
            If Not TlpContainer.Controls.Contains(PnSoldLost) Then
                TlpContainer.Controls.Add(PnSoldLost, 2, 2)
            End If
            TlpContainer.SetRowSpan(PnTitle, 2)
            TlpContainer.SetColumnSpan(PnSoldLost, 2)
        Else
            TlpContainer.RowCount = 1
            If TlpContainer.Controls.Contains(PnSoldLost) Then
                TlpContainer.Controls.Remove(PnSoldLost)
            End If
            TlpContainer.SetRowSpan(PnTitle, 1)

        End If
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
