Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports ControlLibrary

''' <summary>
''' Representa o filtro de avaliações de compressores.
''' </summary>
Public Class VisitScheduleFilter
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
    Public Overridable Property Status As New VisitScheduleStatusExpandable
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(VisitScheduleTypeConverter))>
    <DisplayName("Tipo")>
    Public Overridable Property VisitType As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Instruções")>
    Public Property Instructions As String
    <DisplayName("Cliente")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Customer As New PersonExpandable
    <DisplayName("Compressor")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Compressor As New PersonCompressorExpandable
    <DisplayName("Criação")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Creation As New DateExpandable
    <DisplayName("Data da Visita")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property VisitDate As New DateExpandable
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
            Using Cmd As New MySqlCommand(My.Resources.VisitScheduleFilter, Con)
                If ID <> Nothing Then Cmd.Parameters.AddWithValue("@id", ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@id", "%")
                If Status.Finished = "Sim" Or Status.Finished = Nothing Then StatusList.Add(CInt(VisitScheduleStatus.Finished))
                If Status.Pending = "Sim" Or Status.Pending = Nothing Then StatusList.Add(CInt(VisitScheduleStatus.Pending))
                If Status.Started = "Sim" Or Status.Started = Nothing Then StatusList.Add(CInt(VisitScheduleStatus.Started))
                If Status.Canceled = "Sim" Or Status.Canceled = Nothing Then StatusList.Add(CInt(VisitScheduleStatus.Canceled))
                If VisitType <> Nothing Then Cmd.Parameters.AddWithValue("@visittypeid", CInt(VisitType)) : Filtering = True Else Cmd.Parameters.AddWithValue("@visittypeid", "%")
                Cmd.Parameters.AddWithValue("@statusid", String.Join(",", StatusList)) : Filtering = True
                If Instructions <> Nothing Then Cmd.Parameters.AddWithValue("@instructions", Instructions) : Filtering = True Else Cmd.Parameters.AddWithValue("@instructions", "%")
                If Customer.ID <> Nothing Then Cmd.Parameters.AddWithValue("@customerid", Customer.ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@customerid", "%")
                If Customer.Document <> Nothing Then Cmd.Parameters.AddWithValue("@customerdocument", Customer.Document) : Filtering = True Else Cmd.Parameters.AddWithValue("@customerdocument", "%")
                If Customer.Name <> Nothing Then Cmd.Parameters.AddWithValue("@customername", Customer.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@customername", "%")
                If Compressor.Name <> Nothing Then Cmd.Parameters.AddWithValue("@compressorname", Compressor.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@compressorname", "%")
                If Compressor.SerialNumber <> Nothing Then Cmd.Parameters.AddWithValue("@serialnumber", Compressor.SerialNumber) : Filtering = True Else Cmd.Parameters.AddWithValue("@serialnumber", "%")
                If Compressor.Patrimony <> Nothing Then Cmd.Parameters.AddWithValue("@patrimony", Compressor.Patrimony) : Filtering = True Else Cmd.Parameters.AddWithValue("@patrimony", "%")
                If Compressor.Sector <> Nothing Then Cmd.Parameters.AddWithValue("@sector", Compressor.Sector) : Filtering = True Else Cmd.Parameters.AddWithValue("@sector", "%")
                If Creation.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@creationi", Creation.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@creationi", "0001-01-01")
                If Creation.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@creationf", Creation.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@creationf", "9999-12-31")
                If VisitDate.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@visitdatei", VisitDate.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@visitdatei", "0001-01-01")
                If VisitDate.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@visitdatef", VisitDate.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@visitdatef", "9999-12-31")
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
        Status = New VisitScheduleStatusExpandable
        VisitType = Nothing
        Instructions = Nothing
        Customer = New PersonExpandable
        Compressor = New PersonCompressorExpandable
        Creation = New DateExpandable
        VisitDate = New DateExpandable
    End Sub
End Class
