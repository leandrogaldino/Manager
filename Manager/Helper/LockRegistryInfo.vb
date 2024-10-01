Public Class LockRegistryInfo
    Public Property IsLocked As Boolean
    Public Property SessionToken As String
    Public Property RegistryID As Long
    Public Property Routine As Routine
    Public Property LockTime As Date
    Public Property LockedBy As New Lazy(Of User)
End Class
