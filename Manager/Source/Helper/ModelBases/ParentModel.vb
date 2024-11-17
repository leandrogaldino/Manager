Imports ControlLibrary
Imports MySql.Data.MySqlClient
Public MustInherit Class ParentModel
    Inherits BaseModel
    Friend WithEvents Timer As New Timers.Timer With {.Enabled = True, .Interval = Locator.GetInstance(Of Session).Setting.General.Release.RefreshBlockedRegistryInterval * 1000 * 60}
    Public Property LockInfo As New LockRegistryInfo
    Protected Function GetLockInfo(Transaction As MySqlTransaction) As LockRegistryInfo
        Dim Lock As LockRegistryInfo
        Dim TableResult As DataTable
        Using Cmd As New MySqlCommand(My.Resources.LockedRegistrySelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@routineid", CInt(Routine))
            Cmd.Parameters.AddWithValue("@registryid", ID)
            Using Adp As New MySqlDataAdapter(Cmd)
                TableResult = New DataTable
                Adp.Fill(TableResult)
            End Using
            If TableResult.Rows.Count = 1 Then
                Lock = New LockRegistryInfo With {
                    .IsLocked = True,
                    .SessionToken = TableResult.Rows(0).Item("session"),
                    .LockedBy = New Lazy(Of User)(Function() New User().Load(TableResult.Rows(0).Item("userid"), False)),
                    .LockTime = TableResult.Rows(0).Item("locktime"),
                    .Routine = Routine,
                    .RegistryID = ID
                }
                Return Lock
            Else
                Return New LockRegistryInfo
            End If
        End Using
    End Function
    Public Sub Lock()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Time As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.LockedRegistryInsert, Con)
                Cmd.Parameters.AddWithValue("@session", Session.Token)
                Cmd.Parameters.AddWithValue("@locktime", Time)
                Cmd.Parameters.AddWithValue("@routineid", CInt(Routine))
                Cmd.Parameters.AddWithValue("@registryid", ID)
                Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                Cmd.ExecuteNonQuery()
                LockInfo.IsLocked = True
                LockInfo.SessionToken = Session.Token
                LockInfo.LockTime = Time
                LockInfo.Routine = Routine
                LockInfo.RegistryID = ID
                LockInfo.LockedBy = New Lazy(Of User)(Function() Locator.GetInstance(Of Session).User)
            End Using
        End Using
    End Sub
    Public Sub Lock(Transaction As MySqlTransaction)
        Dim Session = Locator.GetInstance(Of Session)
        Dim Time As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Using Cmd As New MySqlCommand(My.Resources.LockedRegistryInsert, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@session", Session.Token)
            Cmd.Parameters.AddWithValue("@locktime", Time)
            Cmd.Parameters.AddWithValue("@routineid", CInt(Routine))
            Cmd.Parameters.AddWithValue("@registryid", ID)
            Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
            Cmd.Transaction = Transaction
            Cmd.ExecuteNonQuery()
            LockInfo.IsLocked = True
            LockInfo.SessionToken = Session.Token
            LockInfo.LockTime = Time
            LockInfo.Routine = Routine
            LockInfo.RegistryID = ID
            LockInfo.LockedBy = New Lazy(Of User)(Function() Locator.GetInstance(Of Session).User)
        End Using
    End Sub
    Public Sub Unlock(Transaction As MySqlTransaction)
        Dim Session = Locator.GetInstance(Of Session)
        If Session.User IsNot Nothing Then
            Using Cmd As New MySqlCommand(My.Resources.LockedRegistryDelete, Transaction.Connection)
                Cmd.Transaction = Transaction
                Cmd.Parameters.AddWithValue("@session", Session.Token)
                Cmd.Parameters.AddWithValue("@routineid", CInt(Routine))
                Cmd.Parameters.AddWithValue("@registryid", ID)
                Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                Cmd.ExecuteNonQuery()
                LockInfo.IsLocked = False
                LockInfo.SessionToken = Nothing
                LockInfo.LockTime = Nothing
                LockInfo.Routine = Nothing
                LockInfo.RegistryID = 0
                LockInfo.LockedBy = New Lazy(Of User)(Function() New User())
            End Using
        End If
    End Sub
    Public Sub Unlock()
        Dim Session = Locator.GetInstance(Of Session)
        If Session.User IsNot Nothing Then
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using Cmd As New MySqlCommand(My.Resources.LockedRegistryDelete, Con)
                    Cmd.Parameters.AddWithValue("@session", Session.Token)
                    Cmd.Parameters.AddWithValue("@routineid", CInt(Routine))
                    Cmd.Parameters.AddWithValue("@registryid", ID)
                    Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                    Cmd.ExecuteNonQuery()
                    LockInfo.IsLocked = False
                    LockInfo.SessionToken = Nothing
                    LockInfo.LockTime = Nothing
                    LockInfo.Routine = Nothing
                    LockInfo.RegistryID = 0
                    LockInfo.LockedBy = New Lazy(Of User)(Function() New User())
                End Using
            End Using
        End If
    End Sub
    Private Async Sub Timer_Elapsed(sender As Object, e As EventArgs) Handles Timer.Elapsed
        Dim Session = Locator.GetInstance(Of Session)
        Dim Time As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim ConnectionString As String = Session.Setting.Database.GetConnectionString()
        If LockInfo.IsLocked Then
            Try
                Using Con As New MySqlConnection(ConnectionString)
                    Await Con.OpenAsync()
                    Using Cmd As New MySqlCommand(My.Resources.LockedRegistryUpdate, Con)
                        Cmd.Parameters.AddWithValue("@locktime", Time)
                        Cmd.Parameters.AddWithValue("@session", Session.Token)
                        Cmd.Parameters.AddWithValue("@routineid", CInt(Routine))
                        Cmd.Parameters.AddWithValue("@registryid", ID)
                        Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                        Await Cmd.ExecuteNonQueryAsync()
                        LockInfo.LockTime = Time
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print($"Ocorreu um erro no timer do EmailModel rotina: {Routine} registro: {ID}.")
            End Try
        End If
    End Sub
End Class
