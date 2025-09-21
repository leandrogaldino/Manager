Public Class SellableCode
    Inherits ChildModel
    Public Property Name As String
    Public Property Code As String
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New SellableCode With {
            .Name = Name,
            .Code = Code
        }
        Cloned.SetID(ID)
        Cloned.SetCreation(Creation)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function
End Class
