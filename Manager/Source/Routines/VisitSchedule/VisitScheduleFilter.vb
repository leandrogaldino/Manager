Imports System.ComponentModel
Imports ControlLibrary
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

    <DisplayName("ID do Cliente")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(IntegerConverter))>
    Public Property CustomerID As String

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
        VisitDate.InitialDate = Today.AddMonths(-2)
        VisitDate.FinalDate = Today.AddMonths(1)
        _RemoteDb = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
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
    End Sub
    Public Sub New()
    End Sub
    Public Overridable Function Filter() As Boolean
        Dim Filtering As Boolean
        Dim DateConditions As New List(Of RemoteDB.Condition)
        Dim Conditions As New List(Of RemoteDB.Condition)
        Dim SelectedRow As Long = 0
        Dim FirstRow As Long = 0





        If Creation.InitialDate <> Nothing Then
            'Dim utcDate As DateTime = Creation.InitialDate.ToUniversalTime()
            'Dim epochTime As Long = CType((utcDate - New DateTime(1970, 1, 1)).TotalSeconds, Long)
            DateConditions.Add(New RemoteDB.WhereGreaterThanOrEqualToCondition("creation_date", Creation.InitialDate.ToString("yyyy-MM-dd")))
        Else
            DateConditions.Add(New RemoteDB.WhereGreaterThanOrEqualToCondition("creation_date", "0001-01-01"))
        End If

        If Creation.FinalDate <> Nothing Then
            DateConditions.Add(New RemoteDB.WhereLessThanOrEqualToCondition("creation_date", Creation.FinalDate.ToString("yyyy-MM-dd")))
        Else
            DateConditions.Add(New RemoteDB.WhereLessThanOrEqualToCondition("creation_date", "9999-12-31"))
        End If


        If VisitDate.InitialDate <> Nothing Then
            DateConditions.Add(New RemoteDB.WhereGreaterThanOrEqualToCondition("visit_date", VisitDate.InitialDate.ToString("yyyy-MM-dd")))
        Else
            DateConditions.Add(New RemoteDB.WhereGreaterThanOrEqualToCondition("visit_date", "0001-01-01"))
        End If
        If VisitDate.FinalDate <> Nothing Then
            DateConditions.Add(New RemoteDB.WhereLessThanOrEqualToCondition("visit_date", VisitDate.FinalDate.ToString("yyyy-MM-dd")))
        Else
            DateConditions.Add(New RemoteDB.WhereLessThanOrEqualToCondition("visit_date", "9999-12-31"))
        End If





        If Status.Pending = "Sim" Then
            Conditions = New List(Of RemoteDB.Condition)(DateConditions) From {
                New RemoteDB.WhereEqualToCondition("status_id", Convert.ToInt32(VisitScheduleStatus.Pending))
            }
            _RemoteDb.StartListening("schedule", Conditions)
            Filtering = True
        End If

        Conditions = New List(Of RemoteDB.Condition)





        If Status.Started = "Sim" Then
            Conditions = New List(Of RemoteDB.Condition)(DateConditions) From {
                New RemoteDB.WhereEqualToCondition("status_id", Convert.ToInt32(VisitScheduleStatus.Started))
            }
            _RemoteDb.StartListening("schedule", Conditions)
            Filtering = True
        End If

        Conditions = New List(Of RemoteDB.Condition)

        If Status.Finished = "Sim" Then
            Conditions = New List(Of RemoteDB.Condition)(DateConditions) From {
                New RemoteDB.WhereEqualToCondition("status_id", Convert.ToInt32(VisitScheduleStatus.Finished))
            }
            _RemoteDb.StartListening("schedule", Conditions)
            Filtering = True
        End If

        Conditions = New List(Of RemoteDB.Condition)


        If Status.Canceled = "Sim" Then
            Conditions = New List(Of RemoteDB.Condition)(DateConditions) From {
                New RemoteDB.WhereEqualToCondition("status_id", Convert.ToInt32(VisitScheduleStatus.Canceled))
            }
            _RemoteDb.StartListening("schedule", Conditions)
            Filtering = True
        End If



        If VisitType <> Nothing Then
            DateConditions.Add(New RemoteDB.WhereEqualToCondition("visit_type_id", Convert.ToInt32(EnumHelper.GetEnumValue(Of VisitScheduleType)(VisitType.ToUpper()))))
            Filtering = True
        End If



        If CustomerID <> Nothing Then
            DateConditions.Add(New RemoteDB.WhereEqualToCondition("customer_id", If(IsNumeric(CustomerID), CInt(CustomerID), 0)))
            Filtering = True
        End If










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
        CustomerID = Nothing
        Status = New VisitScheduleStatusExpandable
        VisitType = Nothing
        Creation = New DateExpandable
        VisitDate = New DateExpandable With {
            .InitialDate = Today.AddMonths(-2),
            .FinalDate = Today.AddMonths(1)
        }
    End Sub
End Class
