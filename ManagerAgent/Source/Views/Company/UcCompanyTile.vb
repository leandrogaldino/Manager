
Imports System.IO

Public Class UcCompanyTile
    Public Event ValueChanged As EventHandler
    Private _Company As CompanyModel
    Private _IsSelected As Boolean = False

    Public ReadOnly Property IsSelected As Boolean
        Get
            Return _IsSelected
        End Get
    End Property

    Public Property Company As CompanyModel
        Get
            Return _Company
        End Get
        Set(value As CompanyModel)
            'comparar o objeto
            If value.Document <> _Company?.Document Then
                _Company = value
                LblCompanyName.Text = Company.Name
                LblCompanyDocument.Text = Company.Document
                LblCompanyLocation.Text = Company.Address
                If File.Exists(Company.LogoFileName) Then
                    Using fs As New FileStream(Company.LogoFileName, FileMode.Open, FileAccess.Read)
                        PbxLogo.Image = Image.FromStream(fs)
                    End Using
                End If
                OnValueChanged(Me)
            End If
        End Set
    End Property

    Public Sub New(Company As CompanyModel)
        InitializeComponent()
        Me.Company = Company
        AddHandler Click, AddressOf UcCompanyTile_Click
        AddHandler LblCompanyName.Click, AddressOf UcCompanyTile_Click
        AddHandler LblCompanyDocument.Click, AddressOf UcCompanyTile_Click
        AddHandler LblCompanyLocation.Click, AddressOf UcCompanyTile_Click
        AddHandler PbxLogo.Click, AddressOf UcCompanyTile_Click


        AddHandler DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler LblCompanyName.DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler LblCompanyDocument.DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler LblCompanyLocation.DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler PbxLogo.DoubleClick, AddressOf UcCompanyTile_DoubleClick
    End Sub

    Private Sub UcCompanyTile_DoubleClick(sender As Object, e As EventArgs)
        OnClickAction?.Invoke(Company)
    End Sub
    Private Sub UcCompanyTile_Click(sender As Object, e As EventArgs)
        SetSelected(True)
        Me.Focus()
    End Sub

    Private Sub OnValueChanged(s)
        RaiseEvent ValueChanged(s, EventArgs.Empty)
    End Sub

    Private Sub SelectNextTile()
        Dim tiles = Me.Parent.Controls.OfType(Of UcCompanyTile)().OrderBy(Function(t) t.TabIndex).ToList()

        If tiles.Count = 0 Then Exit Sub

        Dim currentIndex = tiles.FindIndex(Function(t) t.IsSelected)

        If currentIndex = -1 Then
            ' nenhum selecionado → seleciona o primeiro
            tiles(0).SetSelected(True)
        ElseIf currentIndex < tiles.Count - 1 Then
            tiles(currentIndex + 1).SetSelected(True)
        End If
    End Sub

    Private Sub SelectPreviousTile()
        Dim tiles = Me.Parent.Controls.OfType(Of UcCompanyTile)().OrderBy(Function(t) t.TabIndex).ToList()
        Dim currentIndex = tiles.FindIndex(Function(t) t.IsSelected)
        If currentIndex > 0 Then
            tiles(currentIndex - 1).SetSelected(True)
        End If
    End Sub

    Public Sub SetSelected(value As Boolean)
        If _IsSelected = value Then Exit Sub
        _IsSelected = value
        Me.BackColor = If(value, Color.LightBlue, SystemColors.Control)
        If value Then
            Me.Parent.Controls.OfType(Of UcCompanyTile)().Where(Function(t) t IsNot Me).ToList().ForEach(Sub(t) t.SetSelected(False))
        End If
        CType(Me.Parent, FlowLayoutPanel).ScrollControlIntoView(Me)
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Down Then
            SelectNextTile()
            Return True
        End If

        If keyData = Keys.Up Then
            SelectPreviousTile()
            Return True
        End If

        If keyData = Keys.Enter Or keyData = Keys.Space Then
            If Not _IsSelected Then Return True
            OnClickAction?.Invoke(Company)
            Return True
            End If

            Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Property OnClickAction As Action(Of CompanyModel)
End Class
