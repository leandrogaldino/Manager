Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports System.Reflection

Public Class VisitSchedule
    Inherits ModelBase
    'Private _IsSaved As Boolean
    'Public Property Status As VisitScheduleStatus
    'Public Property VisitType As VisitScheduleType
    'Public Property Customer As New Person
    'Public Property Compressor As New PersonCompressor
    'Public Property Instructions As String
    'Public Property GeneratedEvaluation As Lazy(Of Evaluation)

    'Public Sub New()
    '    _Routine = Routine.VisitSchedule
    '    _Creation = Today
    '    Status = VisitScheduleStatus.Pending
    '    VisitType = VisitScheduleType.Gathering
    'End Sub
    'Public Sub Clear()
    '    Unlock()
    '    _IsSaved = False
    '    _ID = 0
    '    _Creation = Today
    '    Status = VisitScheduleStatus.Pending
    '    Customer = New Person()
    '    Compressor = New PersonCompressor()
    '    Instructions = Nothing
    '    GeneratedEvaluation = New Lazy(Of Evaluation)
    'End Sub
    'Public Function Load(Identity As Long, LockMe As Boolean) As VisitSchedule
    '    Dim Session = Locator.GetInstance(Of Session)
    '    Dim TableResult As New DataTable
    '    Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
    '        Con.Open()
    '        Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
    '            Using CmdVisitSchedule As New MySqlCommand(My.Resources.VisitScheduleSelect, Con)
    '                CmdVisitSchedule.Transaction = Tra
    '                CmdVisitSchedule.Parameters.AddWithValue("@id", Identity)
    '                CmdVisitSchedule.Parameters.AddWithValue("@name", Nothing)
    '                CmdVisitSchedule.Parameters.AddWithValue("@state", Nothing)
    '                Using Adp As New MySqlDataAdapter(CmdVisitSchedule)
    '                    Adp.Fill(TableResult)
    '                End Using
    '                If TableResult.Rows.Count = 0 Then
    '                    Clear()
    '                ElseIf TableResult.Rows.Count = 1 Then
    '                    Clear()
    '                    _ID = TableResult.Rows(0).Item("id")
    '                    _Creation = TableResult.Rows(0).Item("creation")
    '                    Status = TableResult.Rows(0).Item("statusid")
    '                    Customer = New Person().Load(TableResult.Rows(0).Item("customerid"), False)
    '                    Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = TableResult.Rows(0).Item("personcompressorid"))
    '                    Instructions = TableResult.Rows(0).Item("instructions").ToString
    '                    GeneratedEvaluation = New Lazy(Of Evaluation)(Function() New Evaluation().Load(1, False))
    '                    LockInfo = GetLockInfo(Tra)
    '                    If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
    '                    _IsSaved = True
    '                Else
    '                    Throw New Exception("Registro não encontrado.")
    '                End If
    '            End Using
    '            Tra.Commit()
    '        End Using
    '    End Using
    '    Return Me
    'End Function
    'Public Shared Function GetID(CityName As String, State As String) As Long
    '    Dim Session = Locator.GetInstance(Of Session)
    '    Dim TableResult As DataTable
    '    Dim ReturnedID As Long
    '    Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
    '        Con.Open()
    '        Using CmdCitySelect As New MySqlCommand(My.Resources.CitySelect, Con)
    '            CmdCitySelect.Parameters.AddWithValue("@id", 0)
    '            CmdCitySelect.Parameters.AddWithValue("@name", CityName)
    '            CmdCitySelect.Parameters.AddWithValue("@state", State)
    '            Using Adp As New MySqlDataAdapter(CmdCitySelect)
    '                TableResult = New DataTable
    '                Adp.Fill(TableResult)
    '            End Using
    '            If TableResult.Rows.Count = 1 Then
    '                ReturnedID = TableResult.Rows(0).Item("id")
    '            Else
    '                ReturnedID = 0
    '            End If
    '        End Using
    '    End Using
    '    Return ReturnedID
    'End Function
    'Public Sub SaveChanges()
    '    If Not _IsSaved Then
    '        Insert()
    '    Else
    '        Update()
    '    End If
    '    _IsSaved = True
    '    Routes.Value.ToList().ForEach(Sub(x) x.IsSaved = True)
    'End Sub
    'Public Sub Delete()
    '    Dim Session = Locator.GetInstance(Of Session)
    '    Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
    '        Con.Open()
    '        Using CmdCityDelete As New MySqlCommand(My.Resources.CityDelete, Con)
    '            CmdCityDelete.Parameters.AddWithValue("@id", ID)
    '            CmdCityDelete.ExecuteNonQuery()
    '            Clear()
    '        End Using
    '    End Using
    'End Sub
    'Private Sub Insert()
    '    Dim Session = Locator.GetInstance(Of Session)
    '    Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
    '        Con.Open()
    '        Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
    '            Using CmdCity As New MySqlCommand(My.Resources.CityInsert, Con)
    '                CmdCity.Transaction = Tra
    '                CmdCity.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
    '                CmdCity.Parameters.AddWithValue("@statusid", CInt(Status))
    '                CmdCity.Parameters.AddWithValue("@name", Name)
    '                CmdCity.Parameters.AddWithValue("@bigscode", If(String.IsNullOrEmpty(BIGSCode), DBNull.Value, BIGSCode))
    '                CmdCity.Parameters.AddWithValue("@stateid", If(State.ID = 0, DBNull.Value, State.ID))
    '                CmdCity.Parameters.AddWithValue("@userid", User.ID)
    '                CmdCity.ExecuteNonQuery()
    '                _ID = CmdCity.LastInsertedId
    '            End Using
    '            For Each Route In Routes.Value
    '                Using CmdRoute As New MySqlCommand(My.Resources.CityRouteInsert, Con)
    '                    CmdRoute.Transaction = Tra
    '                    CmdRoute.Parameters.AddWithValue("@cityid", ID)
    '                    CmdRoute.Parameters.AddWithValue("@creation", Route.Creation)
    '                    CmdRoute.Parameters.AddWithValue("@routeid", Route.Route.ID)
    '                    CmdRoute.Parameters.AddWithValue("@userid", Route.User.ID)
    '                    CmdRoute.ExecuteNonQuery()
    '                    Route.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Route, CmdRoute.LastInsertedId)
    '                End Using
    '            Next Route
    '            Tra.Commit()
    '        End Using
    '    End Using
    'End Sub
    'Private Sub Update()
    '    Dim Session = Locator.GetInstance(Of Session)
    '    Dim Shadow As City = New City().Load(ID, False)
    '    Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
    '        Con.Open()
    '        Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
    '            Using CmdCity As New MySqlCommand(My.Resources.CityUpdate, Con)
    '                CmdCity.Transaction = Tra
    '                CmdCity.Parameters.AddWithValue("@id", ID)
    '                CmdCity.Parameters.AddWithValue("@statusid", CInt(Status))
    '                CmdCity.Parameters.AddWithValue("@name", Name)
    '                CmdCity.Parameters.AddWithValue("@bigscode", If(String.IsNullOrEmpty(BIGSCode), DBNull.Value, BIGSCode))
    '                CmdCity.Parameters.AddWithValue("@stateid", If(State.ID = 0, DBNull.Value, State.ID))
    '                CmdCity.Parameters.AddWithValue("@userid", User.ID)
    '                CmdCity.ExecuteNonQuery()
    '            End Using
    '            For Each CityRoute As CityRoute In Shadow.Routes.Value
    '                If Not Routes.Value.Any(Function(x) x.ID = CityRoute.ID And x.ID > 0) Then
    '                    Using CmdCityRoute As New MySqlCommand(My.Resources.CityRouteDelete, Con)
    '                        CmdCityRoute.Transaction = Tra
    '                        CmdCityRoute.Parameters.AddWithValue("@id", CityRoute.ID)
    '                        CmdCityRoute.ExecuteNonQuery()
    '                    End Using
    '                End If
    '            Next CityRoute
    '            For Each Route As CityRoute In Routes.Value
    '                If Route.ID = 0 Then
    '                    Using CmdRoute As New MySqlCommand(My.Resources.CityRouteInsert, Con)
    '                        CmdRoute.Transaction = Tra
    '                        CmdRoute.Parameters.AddWithValue("@cityid", ID)
    '                        CmdRoute.Parameters.AddWithValue("@creation", Route.Creation)
    '                        CmdRoute.Parameters.AddWithValue("@routeid", Route.Route.ID)
    '                        CmdRoute.Parameters.AddWithValue("@userid", Route.User.ID)
    '                        CmdRoute.ExecuteNonQuery()
    '                        Route.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Route, CmdRoute.LastInsertedId)
    '                    End Using
    '                Else
    '                    Using CmdRoute As New MySqlCommand(My.Resources.CityRouteUpdate, Con)
    '                        CmdRoute.Transaction = Tra
    '                        CmdRoute.Parameters.AddWithValue("@id", Route.ID)
    '                        CmdRoute.Parameters.AddWithValue("@routeid", Route.Route.ID)
    '                        CmdRoute.ExecuteNonQuery()
    '                    End Using
    '                End If
    '            Next Route
    '            Tra.Commit()
    '        End Using
    '    End Using
    'End Sub
    'Private Function GetRoutes() As OrdenedList(Of CityRoute)
    '    Dim Session = Locator.GetInstance(Of Session)
    '    Dim TableResult As DataTable
    '    Dim Routes As OrdenedList(Of CityRoute)
    '    Dim Route As CityRoute
    '    Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
    '        Con.Open()
    '        Using CmdCityRoute As New MySqlCommand(My.Resources.CityRouteSelect, Con)
    '            CmdCityRoute.Parameters.AddWithValue("@cityid", ID)
    '            Using Adp As New MySqlDataAdapter(CmdCityRoute)
    '                TableResult = New DataTable
    '                Adp.Fill(TableResult)
    '                Routes = New OrdenedList(Of CityRoute)
    '                For Each Row As DataRow In TableResult.Rows
    '                    Route = New CityRoute()
    '                    Route.Route = New Route().Load(Row.Item("routeid"), False)
    '                    Route.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Route, Row.Item("id"))
    '                    Route.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Route, Row.Item("creation"))
    '                    Route.IsSaved = True
    '                    Routes.Add(Route)
    '                Next Row
    '            End Using
    '        End Using
    '    End Using
    '    Return Routes
    'End Function
    'Public Overrides Function ToString() As String
    '    Return If(Not String.IsNullOrEmpty(Name), Name & " - " & State.ShortName, Nothing)
    'End Function
End Class
