Imports ControlLibrary

Public MustInherit Class BaseModel
    Inherits CloneableModel
    Implements IEquatable(Of BaseModel)

    Private _ID As Long
    Private _Creation As Date = Today
    Private _Routine As Routine
    Private _IsSaved As Boolean


    Public ReadOnly Property ID As Long
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Creation As Date
        Get
            Return _Creation
        End Get
    End Property

    Public ReadOnly Property Routine As Routine
        Get
            Return _Routine
        End Get
    End Property
    Public ReadOnly Property IsSaved As Boolean
        Get
            Return _IsSaved
        End Get
    End Property
    Public ReadOnly Property User As User = Locator.GetInstance(Of Session).User
    Public Sub SetID(ID As Long)
        _ID = ID
    End Sub

    Public Sub SetCreation(Creation As Date)
        _Creation = Creation
    End Sub

    Public Sub SetRoutine(Routine As Routine)
        _Routine = Routine
    End Sub
    Public Sub SetIsSaved(IsSaved As Boolean)
        _IsSaved = IsSaved
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot BaseModel Then Return False
        Return Me.Equals(DirectCast(obj, BaseModel))
    End Function

    Public Overloads Function Equals(other As BaseModel) As Boolean Implements IEquatable(Of BaseModel).Equals
        If other Is Nothing Then Return False
        Return Me.GetType() = other.GetType()
    End Function
End Class
