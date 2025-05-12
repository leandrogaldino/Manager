Imports Force.DeepCloner
Public MustInherit Class CloneableModel
    Public Function Clone() As CloneableModel
        Return DeepClone()
    End Function
End Class
