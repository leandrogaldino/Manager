Public Class UserPrivilege
    Inherits ChildModel
    Private _PrivilegedRoutine As Routine
    Public Property PrivilegedRoutine As Routine
        Get
            Return _PrivilegedRoutine
        End Get
        Set(value As Routine)
            _PrivilegedRoutine = value
            If Not IsBiStatePrivilege AndAlso Not IsTriStatePrivilege Then
                Throw New ArgumentException($"O valor '{value}' não possui os atributos BiStatePrivilege ou TriStatePrivilege.")
            End If
        End Set
    End Property
    Public Property Level As PrivilegeLevel
    Public ReadOnly Property IsBiStatePrivilege As Boolean
        Get
            If [Enum].IsDefined(GetType(Routine), PrivilegedRoutine) Then
                Dim enumType = PrivilegedRoutine.GetType()
                Dim enumField = enumType.GetField(PrivilegedRoutine.ToString())
                If enumField IsNot Nothing Then
                    Return Attribute.IsDefined(enumField, GetType(BiStatePrivilege))
                End If
            End If
            Return False
        End Get
    End Property
    Public ReadOnly Property IsTriStatePrivilege As Boolean
        Get
            If [Enum].IsDefined(GetType(Routine), PrivilegedRoutine) Then
                Dim enumType = PrivilegedRoutine.GetType()
                Dim enumField = enumType.GetField(PrivilegedRoutine.ToString())
                If enumField IsNot Nothing Then
                    Return Attribute.IsDefined(enumField, GetType(TriStatePrivilege))
                End If
            End If
            Return False
        End Get
    End Property
    Public Sub New()
        SetRoutine(Routine.UserPrivilege)
    End Sub
End Class
