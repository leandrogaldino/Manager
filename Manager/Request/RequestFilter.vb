Imports System.ComponentModel
Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa o filtro das requisoções.
''' </summary>
Public Class RequestFilter
    <Browsable(False)>
    Public Property DataGridView As DataGridView
    <Browsable(False)>
    Public Property PropertyGrid As PropertyGrid
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property ID As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Overridable Property Status As New RequestStatusExpandable
    <DisplayName("Destino")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Destination As String
    <DisplayName("Responsável")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Responsible As String
    <DisplayName("Item")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Item As String

    <DisplayName("Item Perdido")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property LossedItem As String

    <DisplayName("Observação")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Overridable Property Note As String
    Public Sub New(Dgv As DataGridView, Pg As PropertyGrid)
        DataGridView = Dgv
        PropertyGrid = Pg
        Pg.SelectedObject = Me
    End Sub
    Public Sub New()
    End Sub
    Public Overridable Function Filter() As Boolean
        Dim Table As New DataTable
        Dim Filtering As Boolean
        Dim SelectedRow As Long = 0
        Dim FirstRow As Long = 0
        Dim StatusList As New List(Of String)
        If DataGridView IsNot Nothing Then
            If DataGridView.SelectedRows.Count = 1 Then
                SelectedRow = DataGridView.SelectedRows(0).Index
            End If
            FirstRow = DataGridView.FirstDisplayedScrollingRowIndex
        End If
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.RequestFilter, Con)
                If ID <> Nothing Then Cmd.Parameters.AddWithValue("@id", ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@id", "%")
                If Status.Pending = "Sim" Or Status.Pending = Nothing Then StatusList.Add(CInt(RequestStatus.Pending))
                If Status.Partial = "Sim" Or Status.Partial = Nothing Then StatusList.Add(CInt(RequestStatus.Partial))
                If Status.Concluded = "Sim" Or Status.Concluded = Nothing Then StatusList.Add(CInt(RequestStatus.Concluded))
                Cmd.Parameters.AddWithValue("@statusid", String.Join(",", StatusList)) : Filtering = True
                If Destination <> Nothing Then Cmd.Parameters.AddWithValue("@destination", Destination) : Filtering = True Else Cmd.Parameters.AddWithValue("@destination", "%")
                If Responsible <> Nothing Then Cmd.Parameters.AddWithValue("@responsible", Responsible) : Filtering = True Else Cmd.Parameters.AddWithValue("@responsible", "%")
                If Item <> Nothing Then Cmd.Parameters.AddWithValue("@item", Item) : Filtering = True Else Cmd.Parameters.AddWithValue("@item", "%")
                If LossedItem = Nothing Then Cmd.Parameters.AddWithValue("@losseditem", 0) : Filtering = True
                If LossedItem = "Sim" Then Cmd.Parameters.AddWithValue("@losseditem", 1) : Filtering = True
                If LossedItem = "Não" Then Cmd.Parameters.AddWithValue("@losseditem", 2) : Filtering = True
                If Note <> Nothing Then Cmd.Parameters.AddWithValue("@note", Note) : Filtering = True Else Cmd.Parameters.AddWithValue("@note", "%")
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(Table)
                    DataGridView.DataSource = Nothing
                    DataGridView.DataSource = Table
                End Using
            End Using
        End Using
        If DataGridView.Rows.Count > 0 Then
            If SelectedRow < DataGridView.Rows.Count Then
                DataGridView.Rows(SelectedRow).Selected = True
            ElseIf SelectedRow >= DataGridView.Rows.Count Then
                DataGridView.Rows(DataGridView.Rows.Count - 1).Selected = True
            End If
            If DataGridView.DisplayedRowCount(True) > 0 Then
                If FirstRow > 0 Then
                    If DataGridView.Rows.Count >= FirstRow Then
                        DataGridView.FirstDisplayedScrollingRowIndex = FirstRow
                    Else
                        DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.Rows.Count - 1
                    End If
                Else
                    DataGridView.FirstDisplayedScrollingRowIndex = 0
                End If
            End If
        End If
        Return Filtering
    End Function
    Public Sub Clean()
        ID = Nothing
        Status = New RequestStatusExpandable
        Destination = Nothing
        Responsible = Nothing
        Item = Nothing
        Note = Nothing
    End Sub
End Class
