Imports ControlLibrary

Public Class UserPrivilege
    Public IsSaved As Boolean
    Private _Order As Long
    Private _ID As Long
    Private _Creation As Date = Today
    Private _Routine As Routine
    Public ReadOnly Property Order As Long
        Get
            Return _Order
        End Get
    End Property
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
    Public Property Routine As Routine
        Get
            Return _Routine
        End Get
        Set(value As Routine)
            _Routine = value
            If Not IsBiStatePrivilege AndAlso Not IsTriStatePrivilege Then
                Throw New ArgumentException($"O valor '{value}' não possui os atributos BiStatePrivilege ou TriStatePrivilege.")
            End If
        End Set
    End Property

    Public Property Level As PrivilegeLevel
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User




    Public ReadOnly Property IsBiStatePrivilege As Boolean
        Get
            If [Enum].IsDefined(GetType(Routine), Routine) Then
                Dim enumType = Routine.GetType()
                Dim enumField = enumType.GetField(Routine.ToString())
                If enumField IsNot Nothing Then
                    Return Attribute.IsDefined(enumField, GetType(BiStatePrivilege))
                End If
            End If
            Return False
        End Get
    End Property
    Public ReadOnly Property IsTriStatePrivilege As Boolean
        Get
            If [Enum].IsDefined(GetType(Routine), Routine) Then
                Dim enumType = Routine.GetType()
                Dim enumField = enumType.GetField(Routine.ToString())
                If enumField IsNot Nothing Then
                    Return Attribute.IsDefined(enumField, GetType(TriStatePrivilege))
                End If
            End If
            Return False
        End Get
    End Property
End Class
