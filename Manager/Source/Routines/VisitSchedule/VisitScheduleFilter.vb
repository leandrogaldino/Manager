Imports System.ComponentModel
Imports ControlLibrary
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports ManagerCore
Imports MySql.Data.MySqlClient


''' <summary>
''' Representa o filtro de avaliações de compressores.
''' </summary>
Public Class VisitScheduleFilter
    Private _RemoteDb As RemoteDB
    <Browsable(False)>
    Public Property DataGridView As DataGridView
    <Browsable(False)>
    Public Property PropertyGrid As PropertyGrid

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
        _RemoteDb = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
    End Sub
    Public Sub New()
    End Sub
    Public Overridable Function Filter() As Boolean
        Dim Filtering As Boolean
        Dim Conditions As New List(Of RemoteDB.Condition)
        Dim FilteredItems As List(Of Integer)
        Dim SelectedRow As Long = 0
        Dim FirstRow As Long = 0
        FilteredItems = New List(Of Integer)
        If Status.Pending = "Sim" Then
            FilteredItems.Add(Convert.ToInt32(VisitScheduleStatus.Pending))
            Filtering = True
        End If
        If Status.Started = "Sim" Then
            FilteredItems.Add(Convert.ToInt32(VisitScheduleStatus.Started))
            Filtering = True
        End If
        If Status.Finished = "Sim" Then
            FilteredItems.Add(Convert.ToInt32(VisitScheduleStatus.Finished))
            Filtering = True
        End If
        If Status.Canceled = "Sim" Then
            FilteredItems.Add(Convert.ToInt32(VisitScheduleStatus.Canceled))
            Filtering = True
        End If

        Conditions.Add(New RemoteDB.WhereInCondition("status_id", FilteredItems))


        If VisitType <> Nothing Then
            Conditions.Add(New RemoteDB.WhereEqualToCondition("visit_type_id", Convert.ToInt32(EnumHelper.GetEnumValue(Of VisitScheduleType)(VisitType.ToUpper()))))
            Filtering = True
        End If
        If Instructions <> Nothing Then
            Conditions.Add(New RemoteDB.WhereInCondition("instructions", Instructions.Split(" "c)))
        End If

        FilteredItems = New List(Of Integer)

        If Customer.ID <> Nothing Then
            FilteredItems.Add(Convert.ToInt32(Customer.ID))
            Filtering = True
        End If
        If Customer.Name <> Nothing Then
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using Cmd As New MySqlCommand("select id from person where name like @name or shortname like @shortname and iscustomer = 1;", Con)
                    Cmd.Parameters.AddWithValue("@name", Customer.Name)
                    Cmd.Parameters.AddWithValue("@shortname", Customer.Name)
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            FilteredItems.Add(Reader.GetInt32("id"))
                        End While
                        Filtering = True
                    End Using
                End Using
            End Using
        End If
        If Customer.Document <> Nothing Then
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using Cmd As New MySqlCommand("select id from person where document like @document iscustomer = 1;", Con)
                    Cmd.Parameters.AddWithValue("@document", Customer.Document)
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            FilteredItems.Add(Reader.GetInt32("id"))
                        End While
                        Filtering = True
                    End Using
                End Using
            End Using
        End If
        If FilteredItems.Count > 0 Then
            FilteredItems = FilteredItems.Distinct()
            Conditions.Add(New RemoteDB.WhereInCondition("customer_id", FilteredItems))
        End If


        FilteredItems = New List(Of Integer)



        If Compressor.Name <> Nothing Then
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using Cmd As New MySqlCommand("select personcompressor.id from personcompressor left join compressor on compressor.id = personcompressor.compressorid where compressor.name like @name;", Con)
                    Cmd.Parameters.AddWithValue("@name", Compressor.Name)
                    Dim Results As New List(Of Integer)()
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            FilteredItems.Add(Reader.GetInt32("id"))
                        End While
                        Filtering = True
                    End Using
                End Using
            End Using
        End If
        If Compressor.Sector <> Nothing Then
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using Cmd As New MySqlCommand("select personcompressor.id from personcompressor where personcompressor.sector like @sector;", Con)
                    Cmd.Parameters.AddWithValue("@sector", Compressor.Sector)
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            FilteredItems.Add(Reader.GetInt32("id"))
                        End While
                        Filtering = True
                    End Using
                End Using
            End Using
        End If
        If Compressor.SerialNumber <> Nothing Then
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using Cmd As New MySqlCommand("select personcompressor.id from personcompressor where personcompressor.serialnumber like @serialnumber;", Con)
                    Cmd.Parameters.AddWithValue("@serialnumber", Compressor.SerialNumber)
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            FilteredItems.Add(Reader.GetInt32("id"))
                        End While
                        Filtering = True
                    End Using
                End Using
            End Using
        End If
        If Compressor.Patrimony <> Nothing Then
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using Cmd As New MySqlCommand("select personcompressor.id from personcompressor where personcompressor.patrimony like @patrimony;", Con)
                    Cmd.Parameters.AddWithValue("@patrimony", Compressor.Patrimony)
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            FilteredItems.Add(Reader.GetInt32("id"))
                        End While
                        Filtering = True
                    End Using
                End Using
            End Using
        End If
        If FilteredItems.Count > 0 Then
            FilteredItems = FilteredItems.Distinct()
            Conditions.Add(New RemoteDB.WhereInCondition("compressor_id", FilteredItems))
        End If

        FilteredItems = New List(Of Integer)


        If Creation.InitialDate <> Nothing Then
            Conditions.Add(New RemoteDB.WhereGreaterThanCondition("creation_date", Creation.InitialDate))
        End If
        If Creation.FinalDate <> Nothing Then
            Conditions.Add(New RemoteDB.WhereLessThanOrEqualToCondition("creation_date", Creation.FinalDate))
        End If


        If VisitDate.InitialDate <> Nothing Then
            Conditions.Add(New RemoteDB.WhereGreaterThanCondition("visit_date", VisitDate.InitialDate))
        End If
        If VisitDate.FinalDate <> Nothing Then
            Conditions.Add(New RemoteDB.WhereLessThanOrEqualToCondition("visit_date", VisitDate.FinalDate))
        End If



        _RemoteDb.StartListening("schedule", Conditions)

        AddHandler _RemoteDb.OnFirestoreChanged,
            Sub(Args)
                Dim Visits As New List(Of VisitSchedule)
                Dim Visit As VisitSchedule
                For Each Document In Args.Documents
                    Visit = New VisitSchedule()
                    Visit.FromCloud(Document)
                    Visits.Add(Visit)
                Next Document
                If DataGridView.InvokeRequired Then
                    DataGridView.Invoke(Sub() DataGridView.DataSource = Visits)
                Else
                    DataGridView.DataSource = Visits
                End If
            End Sub

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
        Status = New VisitScheduleStatusExpandable
        VisitType = Nothing
        Instructions = Nothing
        Customer = New PersonExpandable
        Compressor = New PersonCompressorExpandable
        Creation = New DateExpandable
        VisitDate = New DateExpandable
    End Sub
End Class
