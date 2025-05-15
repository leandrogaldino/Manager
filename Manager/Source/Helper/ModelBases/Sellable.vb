Public Class Sellable
    Inherits ParentModel
    Public Property Name As String
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Note As String
End Class