Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports ControlLibrary
''' <summary>
''' Representa o filtro dos caixas.
''' </summary>
Public Class CashFilter
    <Browsable(False)>
    Public Property CashFlow As CashFlow
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
    <TypeConverter(GetType(CashStatusConverter))>
    Public Overridable Property Status As String

    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Observação")>
    Public Property Note As String

    <DisplayName("Criação")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Creation As New DateExpandable

    <DisplayName("Item")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property CashItem As New CashItemExpandable
    Public Sub New(Dgv As DataGridView, Pg As PropertyGrid, Cf As CashFlow)
        DataGridView = Dgv
        PropertyGrid = Pg
        Pg.SelectedObject = Me
        CashFlow = Cf
    End Sub
    Public Sub New()
    End Sub
    Public Overridable Function Filter() As Boolean
        Dim Session = Locator.GetInstance(Of Session)
        Dim Table As New DataTable
        Dim Filtering As Boolean
        Dim SelectedRow As Long = 0
        Dim FirstRow As Long = 0
        If DataGridView IsNot Nothing Then
            If DataGridView.SelectedRows.Count = 1 Then
                SelectedRow = DataGridView.SelectedRows(0).Index
            End If
            FirstRow = DataGridView.FirstDisplayedScrollingRowIndex
        End If
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.CashFilter, Con)
                Cmd.Parameters.AddWithValue("@cashflowid", CashFlow.ID)
                If ID <> Nothing Then Cmd.Parameters.AddWithValue("@id", ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@id", "%")
                If Status <> Nothing Then Cmd.Parameters.AddWithValue("@statusid", If(Status = EnumHelper.GetEnumDescription(CashStatus.Opened), CInt(CashStatus.Opened), CInt(CashStatus.Closed))) : Filtering = True Else Cmd.Parameters.AddWithValue("@statusid", "%")
                If Note <> Nothing Then Cmd.Parameters.AddWithValue("@note", Note) : Filtering = True Else Cmd.Parameters.AddWithValue("@note", "%")
                If Creation.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@creationi", Creation.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@creationi", "0000-01-01")
                If Creation.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@creationf", Creation.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@creationf", "9999-12-31")
                If CashItem.Description <> Nothing Then Cmd.Parameters.AddWithValue("@description", CashItem.Description) : Filtering = True Else Cmd.Parameters.AddWithValue("@description", "%")
                If CashItem.DocumentNumber <> Nothing Then Cmd.Parameters.AddWithValue("@documentnumber", CashItem.DocumentNumber) : Filtering = True Else Cmd.Parameters.AddWithValue("@documentnumber", "%")
                If CashItem.DocumentDate.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@documentdatei", CashItem.DocumentDate.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@documentdatei", "0001-01-01")
                If CashItem.DocumentDate.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@documentdatef", CashItem.DocumentDate.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@documentdatef", "9999-12-31")
                If CashItem.Value.MinimumValue <> Nothing Then Cmd.Parameters.AddWithValue("@valuemin", CashItem.Value.MinimumValue) : Filtering = True Else Cmd.Parameters.AddWithValue("@valuemin", -9999999999)
                If CashItem.Value.MaximumValue <> Nothing Then Cmd.Parameters.AddWithValue("@valuemax", CashItem.Value.MaximumValue) : Filtering = True Else Cmd.Parameters.AddWithValue("@valuemax", 9999999999)
                If CashItem.Responsible.ID <> Nothing Then Cmd.Parameters.AddWithValue("@responsibleid", CashItem.Responsible.ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@responsibleid", "%")
                If CashItem.Responsible.Document <> Nothing Then Cmd.Parameters.AddWithValue("@responsibledocument", CashItem.Responsible.Document) : Filtering = True Else Cmd.Parameters.AddWithValue("@responsibledocument", "%")
                If CashItem.Responsible.Name <> Nothing Then Cmd.Parameters.AddWithValue("@responsiblename", CashItem.Responsible.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@responsiblename", "%")
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
        Status = Nothing
        Note = Nothing
        Creation = New DateExpandable
        CashItem = New CashItemExpandable
    End Sub
End Class
