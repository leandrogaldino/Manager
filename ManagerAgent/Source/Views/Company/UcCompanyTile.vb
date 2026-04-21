Imports System.IO
Imports ManagerCore

Public Class UcCompanyTile
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
            _Company = value
        End Set
    End Property

    Public Sub New(Company As CompanyModel)
        InitializeComponent()
        Me.Company = Company
        RegisterHandlers()
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim Address As New List(Of String)
        LblStatus.Text = If(Company.IsActive, "Ativo", "Inativo")
        LblStatus.ForeColor = If(Company.IsActive, Color.DodgerBlue, Color.Firebrick)
        LblCompanyName.Text = Company.ShortName
        LblCompanyDocument.Text = Company.Document
        If Not String.IsNullOrEmpty(Company.Address.City) Then Address.Add(Company.Address.City)
        If Not String.IsNullOrEmpty(Company.Address.State) Then Address.Add(Company.Address.State)
        If Address.Count > 0 Then
            LblCompanyLocation.Text = String.Join(" - ", Address)
        End If
        If Company.Logo.CurrentFile IsNot Nothing AndAlso File.Exists(Company.Logo.CurrentFile) Then
            Using Stream As New FileStream(Company.Logo.CurrentFile, FileMode.Open, FileAccess.Read)
                Using imgTemp = Image.FromStream(Stream)
                    PbxLogo.Image = New Bitmap(imgTemp)
                End Using
            End Using
        Else
            PbxLogo.Image = Nothing
        End If
    End Sub

    Public Sub Reload()
        LoadData()
    End Sub
    Private Sub RegisterHandlers()
        AddHandler Click, AddressOf UcCompanyTile_Click
        AddHandler LblCompanyName.Click, AddressOf UcCompanyTile_Click
        AddHandler LblCompanyDocument.Click, AddressOf UcCompanyTile_Click
        AddHandler LblCompanyLocation.Click, AddressOf UcCompanyTile_Click
        AddHandler PbxLogo.Click, AddressOf UcCompanyTile_Click
        AddHandler LblStatus.Click, AddressOf UcCompanyTile_Click
        AddHandler DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler LblCompanyName.DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler LblCompanyDocument.DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler LblCompanyLocation.DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler PbxLogo.DoubleClick, AddressOf UcCompanyTile_DoubleClick
        AddHandler LblStatus.DoubleClick, AddressOf UcCompanyTile_DoubleClick
    End Sub

    Private Sub UcCompanyTile_DoubleClick(sender As Object, e As EventArgs)
        OnClickAction?.Invoke(Company)
        RaiseEvent ActionEnded(Me, EventArgs.Empty)
    End Sub
    Private Sub UcCompanyTile_Click(sender As Object, e As EventArgs)
        SetSelected(True)
        Me.Focus()
    End Sub
    Private Sub SelectNextTile()
        Dim Tiles = Me.Parent.Controls.OfType(Of UcCompanyTile)().OrderBy(Function(t) t.TabIndex).ToList()
        If Tiles.Count = 0 Then Exit Sub
        Dim currentIndex = Tiles.FindIndex(Function(t) t.IsSelected)
        If currentIndex = -1 Then
            Tiles(0).SetSelected(True)
        ElseIf currentIndex < Tiles.Count - 1 Then
            Tiles(currentIndex + 1).SetSelected(True)
        End If
    End Sub
    Private Sub SelectPreviousTile()
        Dim Tiles = Me.Parent.Controls.OfType(Of UcCompanyTile)().OrderBy(Function(t) t.TabIndex).ToList()
        Dim CurrentIndex = Tiles.FindIndex(Function(t) t.IsSelected)
        If CurrentIndex > 0 Then
            Tiles(CurrentIndex - 1).SetSelected(True)
        End If
    End Sub
    Public Sub SetSelected(value As Boolean)
        If _IsSelected = value Then Exit Sub
        _IsSelected = value
        If Company.IsActive Then
            Me.BackColor = If(value, Color.Azure, Color.White)
        Else
            Me.BackColor = If(value, Color.MistyRose, Color.White)
        End If
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
            RaiseEvent ActionEnded(Me, EventArgs.Empty)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Property OnClickAction As Action(Of CompanyModel)
    Public Event ActionEnded As EventHandler
End Class
