
Public Class CompanyLocalDatabaseModel
    Public Property Server As String
    Public Property Name As String
    Public Property Username As String
    Public Property Password As String
    Public Function GetConnectionString() As String
        Return String.Format("Server={0};Database={1};Uid={2};Pwd={3};Pooling=True", Server, Name, Username, Password)
    End Function
End Class
