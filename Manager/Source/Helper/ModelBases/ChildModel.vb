
Public MustInherit Class ChildModel
    Inherits BaseModel
    Private _Guid As String = System.Guid.NewGuid().ToString()
    Public ReadOnly Property Guid As String
        Get
            Return _Guid
        End Get
    End Property
End Class
