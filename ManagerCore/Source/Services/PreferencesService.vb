Imports System.Data.Common
Imports System.Globalization
Imports System.Transactions
Imports CoreSuite.Services

Public Class PreferencesService
    Private ReadOnly _LocalDb As MySqlService
    Public Sub New(LocalDb As MySqlService)
        _LocalDb = LocalDb
    End Sub
    Public Async Function LoadAsync() As Task(Of PreferencesModel)
        Dim Result = Await _LocalDb.Request.ExecuteRawQueryAsync("SELECT `group`, `key`, `value` FROM preferences")
        Dim Model As New PreferencesModel
        If Result.Data Is Nothing Then Return Model
        For Each Row In Result.Data
            Dim Group = Row("group").ToString()
            Dim Key = Row("key").ToString()
            Dim Value = If(Row("value"), Nothing)?.ToString()
            Select Case Group
                Case "Backup"
                    Select Case Key
                        Case "Monday" : Model.Backup.Monday = ToBool(Value)
                        Case "Tuesday" : Model.Backup.Tuesday = ToBool(Value)
                        Case "Wednesday" : Model.Backup.Wednesday = ToBool(Value)
                        Case "Thursday" : Model.Backup.Thursday = ToBool(Value)
                        Case "Friday" : Model.Backup.Friday = ToBool(Value)
                        Case "Saturday" : Model.Backup.Saturday = ToBool(Value)
                        Case "Sunday" : Model.Backup.Sunday = ToBool(Value)
                        Case "Time" : Model.Backup.Time = ToTimeSpan(Value)
                        Case "Keep" : Model.Backup.Keep = ToInt(Value)
                        Case "IgnoreNext" : Model.Backup.IgnoreNext = ToBool(Value)
                        Case "Location" : Model.Backup.Location = Value
                    End Select
                Case "Support"
                    Select Case Key
                        Case "EnableSSL" : Model.Support.EnableSSL = ToBool(Value)
                        Case "Email" : Model.Support.Email = Value
                        Case "SMTPServer" : Model.Support.SMTPServer = Value
                        Case "Port" : Model.Support.Port = ToInt(Value)
                        Case "Password" : Model.Support.Password = Value
                    End Select
                Case "LastExecution"
                    Select Case Key
                        Case "Backup" : Model.LastExecution.Backup = ToDate(Value)
                        Case "Clean" : Model.LastExecution.Clean = ToDate(Value)
                        Case "Release" : Model.LastExecution.Release = ToDate(Value)
                        Case "CloudSync" : Model.LastExecution.CloudSync = ToDate(Value)
                    End Select
                Case "Clean"
                    If Key = "Interval" Then
                        Model.Parameters.Clean.Interval = ToInt(Value)
                    End If
                Case "Release"
                    Select Case Key
                        Case "RefreshBlockedRegistryInterval"
                            Model.Parameters.Release.RefreshBlockedRegistryInterval = ToInt(Value)
                        Case "ReleaseBlockedRegisterInterval"
                            Model.Parameters.Release.ReleaseBlockedRegisterInterval = ToInt(Value)
                    End Select
                Case "Evaluation"
                    Select Case Key
                        Case "DaysBeforeMaintenanceAlert" : Model.Parameters.Evaluation.DaysBeforeMaintenanceAlert = ToInt(Value)
                        Case "DaysBeforeVisitAlert" : Model.Parameters.Evaluation.DaysBeforeVisitAlert = ToInt(Value)
                        Case "MonthsBeforeRecordDeletion" : Model.Parameters.Evaluation.MonthsBeforeRecordDeletion = ToInt(Value)
                        Case "FooterMaintenancePlan" : Model.Parameters.Evaluation.FooterMaintenancePlan = Value
                    End Select
                Case "User"
                    If Key = "DefaultPassword" Then
                        Model.Parameters.User.DefaultPassword = Value
                    End If
                Case "Sync"
                    If Key = "Interval" Then
                        Model.Parameters.Sync.Interval = Value
                    End If
            End Select
        Next Row
        Return Model
    End Function
    Public Async Function SaveAsync(Model As PreferencesModel) As Task
        Using Connection As DbConnection = _LocalDb.Client.CreateDatabaseConnection()
            Using Transaction As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                Await SaveValue("Backup", "Monday", Model.Backup.Monday, Connection)
                Await SaveValue("Backup", "Tuesday", Model.Backup.Tuesday, Connection)
                Await SaveValue("Backup", "Wednesday", Model.Backup.Wednesday, Connection)
                Await SaveValue("Backup", "Thursday", Model.Backup.Thursday, Connection)
                Await SaveValue("Backup", "Friday", Model.Backup.Friday, Connection)
                Await SaveValue("Backup", "Saturday", Model.Backup.Saturday, Connection)
                Await SaveValue("Backup", "Sunday", Model.Backup.Sunday, Connection)
                Await SaveValue("Backup", "Time", Model.Backup.Time.ToString(), Connection)
                Await SaveValue("Backup", "Keep", Model.Backup.Keep, Connection)
                Await SaveValue("Backup", "IgnoreNext", Model.Backup.IgnoreNext, Connection)
                Await SaveValue("Backup", "Location", Model.Backup.Location, Connection)
                Await SaveValue("Support", "EnableSSL", Model.Support.EnableSSL, Connection)
                Await SaveValue("Support", "Email", Model.Support.Email, Connection)
                Await SaveValue("Support", "SMTPServer", Model.Support.SMTPServer, Connection)
                Await SaveValue("Support", "Port", Model.Support.Port, Connection)
                Await SaveValue("Support", "Password", Model.Support.Password, Connection)
                Await SaveValue("LastExecution", "Backup", Model.LastExecution.Backup, Connection)
                Await SaveValue("LastExecution", "Clean", Model.LastExecution.Clean, Connection)
                Await SaveValue("LastExecution", "Release", Model.LastExecution.Release, Connection)
                Await SaveValue("LastExecution", "CloudSync", Model.LastExecution.CloudSync, Connection)
                Await SaveValue("Clean", "Interval", Model.Parameters.Clean.Interval, Connection)
                Await SaveValue("Release", "RefreshBlockedRegistryInterval", Model.Parameters.Release.RefreshBlockedRegistryInterval, Connection)
                Await SaveValue("Release", "ReleaseBlockedRegisterInterval", Model.Parameters.Release.ReleaseBlockedRegisterInterval, Connection)
                Await SaveValue("Evaluation", "DaysBeforeMaintenanceAlert", Model.Parameters.Evaluation.DaysBeforeMaintenanceAlert, Connection)
                Await SaveValue("Evaluation", "DaysBeforeVisitAlert", Model.Parameters.Evaluation.DaysBeforeVisitAlert, Connection)
                Await SaveValue("Evaluation", "MonthsBeforeRecordDeletion", Model.Parameters.Evaluation.MonthsBeforeRecordDeletion, Connection)
                Await SaveValue("Evaluation", "FooterMaintenancePlan", Model.Parameters.Evaluation.FooterMaintenancePlan, Connection)
                Await SaveValue("User", "DefaultPassword", Model.Parameters.User.DefaultPassword, Connection)
                Await SaveValue("Sync", "Interval", Model.Parameters.Sync.Interval, Connection)
                Transaction.Complete()
            End Using
        End Using
    End Function
    Private Async Function SaveValue(Group As String, Key As String, Value As Object, Connection As DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "UPDATE preferences SET `value` = @value WHERE `group` = @group AND `key` = @key",
            New Dictionary(Of String, Object) From {
                {"@group", Group},
                {"@key", Key},
                {"@value", If(Value Is Nothing, DBNull.Value, Value.ToString())}
            }, Connection)
    End Function
    Private Function ToBool(Value As String) As Boolean
        Return Not String.IsNullOrEmpty(Value) AndAlso Value.Equals("true", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function ToInt(Value As String) As Integer
        Dim i As Integer
        Integer.TryParse(Value, i)
        Return i
    End Function
    Private Function ToDate(Value As String) As Date
        Dim d As Date
        Date.TryParse(Value, CultureInfo.InvariantCulture, DateTimeStyles.None, d)
        Return d
    End Function
    Private Function ToTimeSpan(Value As String) As TimeSpan
        Dim t As TimeSpan
        TimeSpan.TryParse(Value, CultureInfo.InvariantCulture, t)
        Return t
    End Function
End Class
