Imports MySql.Data.MySqlClient
Imports ControlLibrary
Imports System.Reflection
''' <summary>
''' Representa um fluxo de caixa.
''' </summary>
Public Class CashFlow
    Inherits ModelBase
    Private _IsSaved As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Authorized As New OrdenedList(Of CashFlowAuthorized)
    Public Sub New()
        _Routine = Routine.CashFlow
    End Sub
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        Status = SimpleStatus.Active
        Name = Nothing
    End Sub

    Public Function GetAuthorized(Transaction As MySqlTransaction) As OrdenedList(Of CashFlowAuthorized)
        Dim TableResult As DataTable
        Dim AuthorizedList As OrdenedList(Of CashFlowAuthorized)
        Dim FlowAuthorized As CashFlowAuthorized
        Using CmdAuthorized As New MySqlCommand(My.Resources.CashFlowAuthorizedSelect, Transaction.Connection)
            CmdAuthorized.Transaction = Transaction
            CmdAuthorized.Parameters.AddWithValue("@cashflowid", ID)
            Using Adp As New MySqlDataAdapter(CmdAuthorized)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                AuthorizedList = New OrdenedList(Of CashFlowAuthorized)
                For Each Row As DataRow In TableResult.Rows
                    FlowAuthorized = New CashFlowAuthorized()
                    FlowAuthorized.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(FlowAuthorized, Row.Item("id"))
                    FlowAuthorized.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(FlowAuthorized, Row.Item("creation"))
                    FlowAuthorized.Authorized = New Person().Load(Row.Item("authorizedid"), False)
                    FlowAuthorized.IsSaved = True
                    AuthorizedList.Add(FlowAuthorized)
                Next Row
            End Using
        End Using
        Return AuthorizedList
    End Function
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
                        _ID = TableResult.Rows(0).Item("id")
                        _Creation = TableResult.Rows(0).Item("creation")
                        Status = TableResult.Rows(0).Item("statusid")
                        Name = TableResult.Rows(0).Item("name").ToString
                        Authorized = GetAuthorized(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                        _IsSaved = True
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not _IsSaved Then
            Insert()
        Else
            Update()
        End If
        _IsSaved = True
        Authorized.ToList().ForEach(Sub(x) x.IsSaved = True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.CashFlowDelete, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.ExecuteNonQuery()
                Clear()
            End Using
        End Using
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
                    _ID = Cmd.LastInsertedId
                End Using
                For Each FlowAuthorized As CashFlowAuthorized In Me.Authorized
                    Using Cmd As New MySqlCommand(My.Resources.CashFlowAuthorizedInsert, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@cashflowid", ID)
                        Cmd.Parameters.AddWithValue("@creation", FlowAuthorized.Creation)
                        Cmd.Parameters.AddWithValue("@authorizedid", If(FlowAuthorized.Authorized.ID = 0, DBNull.Value, FlowAuthorized.Authorized.ID))
                        Cmd.Parameters.AddWithValue("@userid", FlowAuthorized.User.ID)
                        Cmd.ExecuteNonQuery()
                        FlowAuthorized.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(FlowAuthorized, Cmd.LastInsertedId)
                    End Using
                Next FlowAuthorized
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Shadow As CashFlow = New CashFlow().Load(ID, False)
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
                For Each FlowAuhorized As CashFlowAuthorized In Shadow.Authorized
                    If Not Authorized.Any(Function(x) x.ID = FlowAuhorized.ID And x.ID > 0) Then
                        Using CmdCompressorPart As New MySqlCommand(My.Resources.CashFlowAuthorizedDelete, Con)
                            CmdCompressorPart.Transaction = Tra
                            CmdCompressorPart.Parameters.AddWithValue("@id", FlowAuhorized.ID)
                            CmdCompressorPart.ExecuteNonQuery()
                        End Using
                    End If
                Next FlowAuhorized
                For Each FlowAuhorized As CashFlowAuthorized In Authorized
                    If FlowAuhorized.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.CashFlowAuthorizedInsert, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@cashflowid", ID)
                            Cmd.Parameters.AddWithValue("@creation", FlowAuhorized.Creation)
                            Cmd.Parameters.AddWithValue("@authorizedid", If(FlowAuhorized.Authorized.ID = 0, DBNull.Value, FlowAuhorized.Authorized.ID))
                            Cmd.Parameters.AddWithValue("@userid", FlowAuhorized.User.ID)
                            Cmd.ExecuteNonQuery()
                            FlowAuhorized.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(FlowAuhorized, Cmd.LastInsertedId)
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
End Class
