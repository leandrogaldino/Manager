<AttributeUsage(AttributeTargets.Field, Inherited:=False, AllowMultiple:=False)>
Public Class RoutineDependencyAttribute
    Inherits Attribute
    Public Property Dependency As Routine
    Public Sub New(Dependency As Routine)
        Me.Dependency = Dependency
    End Sub
End Class


