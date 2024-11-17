Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma cidade.
''' </summary>
Public Class City
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property BIGSCode As String
    Public Property State As New State
    Public Property Routes As New Lazy(Of List(Of CityRoute))(Function() GetRoutes())
    Public Sub New()
        SetRoutine(Routine.City)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        Routes = New Lazy(Of List(Of CityRoute))(Function() GetRoutes())
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As City
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCitySelect As New MySqlCommand(My.Resources.CitySelect, Con)
                    CmdCitySelect.Transaction = Tra
                    CmdCitySelect.Parameters.AddWithValue("@id", Identity)
                    CmdCitySelect.Parameters.AddWithValue("@name", Nothing)
                    CmdCitySelect.Parameters.AddWithValue("@state", Nothing)
                    Using Adp As New MySqlDataAdapter(CmdCitySelect)
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        SetIsSaved(True)
                        Status = TableResult.Rows(0).Item("statusid")
                        Name = TableResult.Rows(0).Item("name").ToString
                        BIGSCode = TableResult.Rows(0).Item("bigscode").ToString
                        State = New State().Load(TableResult.Rows(0).Item("stateid"))
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Public Shared Function GetID(CityName As String, State As String) As Long
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Dim ReturnedID As Long
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdCitySelect As New MySqlCommand(My.Resources.CitySelect, Con)
                CmdCitySelect.Parameters.AddWithValue("@id", 0)
                CmdCitySelect.Parameters.AddWithValue("@name", CityName)
                CmdCitySelect.Parameters.AddWithValue("@state", State)
                Using Adp As New MySqlDataAdapter(CmdCitySelect)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                End Using
                If TableResult.Rows.Count = 1 Then
                    ReturnedID = TableResult.Rows(0).Item("id")
                Else
                    ReturnedID = 0
                End If
            End Using
        End Using
        Return ReturnedID
    End Function
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Routes.Value.ToList().ForEach(Sub(x) x.SetIsSaved(True))
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdCityDelete As New MySqlCommand(My.Resources.CityDelete, Con)
                CmdCityDelete.Parameters.AddWithValue("@id", ID)
                CmdCityDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCity As New MySqlCommand(My.Resources.CityInsert, Con)
                    CmdCity.Transaction = Tra
                    CmdCity.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdCity.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdCity.Parameters.AddWithValue("@name", Name)
                    CmdCity.Parameters.AddWithValue("@bigscode", If(String.IsNullOrEmpty(BIGSCode), DBNull.Value, BIGSCode))
                    CmdCity.Parameters.AddWithValue("@stateid", If(State.ID = 0, DBNull.Value, State.ID))
                    CmdCity.Parameters.AddWithValue("@userid", User.ID)
                    CmdCity.ExecuteNonQuery()
                    SetID(CmdCity.LastInsertedId)
                End Using
                For Each Route In Routes.Value
                    Using CmdRoute As New MySqlCommand(My.Resources.CityRouteInsert, Con)
                        CmdRoute.Transaction = Tra
                        CmdRoute.Parameters.AddWithValue("@cityid", ID)
                        CmdRoute.Parameters.AddWithValue("@creation", Route.Creation)
                        CmdRoute.Parameters.AddWithValue("@routeid", Route.Route.ID)
                        CmdRoute.Parameters.AddWithValue("@userid", Route.User.ID)
                        CmdRoute.ExecuteNonQuery()
                        Route.SetID(CmdRoute.LastInsertedId)
                    End Using
                Next Route
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Shadow As City = New City().Load(ID, False)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCity As New MySqlCommand(My.Resources.CityUpdate, Con)
                    CmdCity.Transaction = Tra
                    CmdCity.Parameters.AddWithValue("@id", ID)
                    CmdCity.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdCity.Parameters.AddWithValue("@name", Name)
                    CmdCity.Parameters.AddWithValue("@bigscode", If(String.IsNullOrEmpty(BIGSCode), DBNull.Value, BIGSCode))
                    CmdCity.Parameters.AddWithValue("@stateid", If(State.ID = 0, DBNull.Value, State.ID))
                    CmdCity.Parameters.AddWithValue("@userid", User.ID)
                    CmdCity.ExecuteNonQuery()
                End Using
                For Each CityRoute As CityRoute In Shadow.Routes.Value
                    If Not Routes.Value.Any(Function(x) x.ID = CityRoute.ID And x.ID > 0) Then
                        Using CmdCityRoute As New MySqlCommand(My.Resources.CityRouteDelete, Con)
                            CmdCityRoute.Transaction = Tra
                            CmdCityRoute.Parameters.AddWithValue("@id", CityRoute.ID)
                            CmdCityRoute.ExecuteNonQuery()
                        End Using
                    End If
                Next CityRoute
                For Each Route As CityRoute In Routes.Value
                    If Route.ID = 0 Then
                        Using CmdRoute As New MySqlCommand(My.Resources.CityRouteInsert, Con)
                            CmdRoute.Transaction = Tra
                            CmdRoute.Parameters.AddWithValue("@cityid", ID)
                            CmdRoute.Parameters.AddWithValue("@creation", Route.Creation)
                            CmdRoute.Parameters.AddWithValue("@routeid", Route.Route.ID)
                            CmdRoute.Parameters.AddWithValue("@userid", Route.User.ID)
                            CmdRoute.ExecuteNonQuery()
                            Route.SetID(CmdRoute.LastInsertedId)
                        End Using
                    Else
                        Using CmdRoute As New MySqlCommand(My.Resources.CityRouteUpdate, Con)
                            CmdRoute.Transaction = Tra
                            CmdRoute.Parameters.AddWithValue("@id", Route.ID)
                            CmdRoute.Parameters.AddWithValue("@routeid", Route.Route.ID)
                            CmdRoute.ExecuteNonQuery()
                        End Using
                    End If
                Next Route
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetRoutes() As List(Of CityRoute)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Dim Routes As List(Of CityRoute)
        Dim Route As CityRoute
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdCityRoute As New MySqlCommand(My.Resources.CityRouteSelect, Con)
                CmdCityRoute.Parameters.AddWithValue("@cityid", ID)
                Using Adp As New MySqlDataAdapter(CmdCityRoute)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                    Routes = New List(Of CityRoute)
                    For Each Row As DataRow In TableResult.Rows
                        Route = New CityRoute()
                        Route.Route = New Route().Load(Row.Item("routeid"), False)
                        Route.SetID(Row.Item("id"))
                        Route.SetCreation(Row.Item("creation"))
                        Route.SetIsSaved(True)
                        Routes.Add(Route)
                    Next Row
                End Using
            End Using
        End Using
        Return Routes
    End Function
    Public Overrides Function ToString() As String
        Return If(Not String.IsNullOrEmpty(Name), Name & " - " & State.ShortName, Nothing)
    End Function
End Class
