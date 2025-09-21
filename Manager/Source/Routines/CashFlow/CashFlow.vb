Imports MySql.Data.MySqlClient
Imports ControlLibrary
''' <summary>
''' Representa um fluxo de caixa.
''' </summary>
Public Class CashFlow
    Inherits ParentModel
    Private _Shadow As CashFlow
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Authorizeds As New List(Of CashFlowAuthorized)
    Public Sub New()
        SetRoutine(Routine.CashFlow)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As CashFlow
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.CashFlowSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        TableResult = New DataTable
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
                        Authorizeds = GetAuthorizeds(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        _Shadow = Clone()
        Return Me
    End Function
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Authorizeds.ForEach(Sub(a) a.UpdateUser(Con, Tra))
                Using Cmd As New MySqlCommand(My.Resources.CashFlowDelete, Con, Tra)
                    Cmd.Parameters.AddWithValue("@id", ID)
                    Cmd.ExecuteNonQuery()
                    Clear()
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Authorizeds.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.CashFlowInsert, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                    Cmd.Parameters.AddWithValue("@name", Name)
                    Cmd.Parameters.AddWithValue("@userid", User.ID)
                    Cmd.ExecuteNonQuery()
                    SetID(Cmd.LastInsertedId)
                End Using
                For Each FlowAuthorized As CashFlowAuthorized In Me.Authorizeds
                    Using Cmd As New MySqlCommand(My.Resources.CashFlowAuthorizedInsert, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@cashflowid", ID)
                        Cmd.Parameters.AddWithValue("@creation", FlowAuthorized.Creation)
                        Cmd.Parameters.AddWithValue("@authorizedid", If(FlowAuthorized.Authorized.ID = 0, DBNull.Value, FlowAuthorized.Authorized.ID))
                        Cmd.Parameters.AddWithValue("@userid", FlowAuthorized.User.ID)
                        Cmd.ExecuteNonQuery()
                        FlowAuthorized.SetID(Cmd.LastInsertedId)
                    End Using
                Next FlowAuthorized
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.CashFlowUpdate, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", ID)
                    Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                    Cmd.Parameters.AddWithValue("@name", Name)
                    Cmd.Parameters.AddWithValue("@userid", User.ID)
                    Cmd.ExecuteNonQuery()
                End Using
                For Each FlowAuthorized As CashFlowAuthorized In _Shadow.Authorizeds
                    If Not Authorizeds.Any(Function(x) x.ID = FlowAuthorized.ID And x.ID > 0) Then
                        Using Cmd As New MySqlCommand(My.Resources.CashFlowAuthorizedDelete, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@id", FlowAuthorized.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next FlowAuthorized
                For Each FlowAuhorized As CashFlowAuthorized In Authorizeds
                    If FlowAuhorized.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.CashFlowAuthorizedInsert, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@cashflowid", ID)
                            Cmd.Parameters.AddWithValue("@creation", FlowAuhorized.Creation)
                            Cmd.Parameters.AddWithValue("@authorizedid", If(FlowAuhorized.Authorized.ID = 0, DBNull.Value, FlowAuhorized.Authorized.ID))
                            Cmd.Parameters.AddWithValue("@userid", FlowAuhorized.User.ID)
                            Cmd.ExecuteNonQuery()
                            FlowAuhorized.SetID(Cmd.LastInsertedId)
                        End Using
                    Else
                        Using Cmd As New MySqlCommand(My.Resources.CashFlowAuthorizedUpdate, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@id", FlowAuhorized.ID)
                            Cmd.Parameters.AddWithValue("@authorizedid", If(FlowAuhorized.Authorized.ID = 0, DBNull.Value, FlowAuhorized.Authorized.ID))
                            Cmd.Parameters.AddWithValue("@userid", FlowAuhorized.User.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next FlowAuhorized
                Tra.Commit()
            End Using
        End Using
    End Sub

    Public Function GetAuthorizeds(Transaction As MySqlTransaction) As List(Of CashFlowAuthorized)
        Dim TableResult As DataTable
        Dim AuthorizedList As List(Of CashFlowAuthorized)
        Dim FlowAuthorized As CashFlowAuthorized
        Using CmdAuthorized As New MySqlCommand(My.Resources.CashFlowAuthorizedSelect, Transaction.Connection)
            CmdAuthorized.Transaction = Transaction
            CmdAuthorized.Parameters.AddWithValue("@cashflowid", ID)
            Using Adp As New MySqlDataAdapter(CmdAuthorized)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                AuthorizedList = New List(Of CashFlowAuthorized)
                For Each Row As DataRow In TableResult.Rows
                    FlowAuthorized = New CashFlowAuthorized()
                    FlowAuthorized.SetID(Row.Item("id"))
                    FlowAuthorized.SetCreation(Row.Item("creation"))
                    FlowAuthorized.SetIsSaved(True)
                    FlowAuthorized.Authorized = New Person().Load(Row.Item("authorizedid"), False)
                    AuthorizedList.Add(FlowAuthorized)
                Next Row
            End Using
        End Using
        Return AuthorizedList
    End Function
    Public Shared Function GetCashFlows() As List(Of CashFlow)
        Dim Session = Locator.GetInstance(Of Session)
        Dim Table As New DataTable
        Dim CashFlow As CashFlow
        Dim CashFlows As New List(Of CashFlow)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.CashFlowsIDSelect, Con)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(Table)
                    If Table.Rows.Count > 0 Then
                        For Each Row As DataRow In Table.Rows
                            CashFlow = New CashFlow().Load(Row.Item("id"), False)
                            CashFlows.Add(CashFlow)
                        Next Row
                    End If
                End Using
            End Using
        End Using
        Return CashFlows
    End Function
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New CashFlow With {
            .Name = Name,
            .Status = Status,
            .Authorizeds = Authorizeds.Select(Function(x) CType(x.Clone(), CashFlowAuthorized)).ToList()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function
End Class
