Public Class Sellable
    Inherits ParentModel
    Public Property Name As String
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Note As String

    Public Overrides Function Clone() As BaseModel
        Return New Sellable With {
            .Name = Name,
            .Status = Status,
            .Note = Note
        }
    End Function
End Class