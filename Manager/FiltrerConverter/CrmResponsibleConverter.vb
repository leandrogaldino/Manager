Imports System.ComponentModel
Public Class CrmResponsibleConverter
    Inherits StringConverter
    Private _Usernames As List(Of String)
    Public Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        If _Usernames Is Nothing Then
            _Usernames = User.GetUsersPersonSortName()
            _Usernames.Insert(0, "")
        End If
        Return New StandardValuesCollection(_Usernames)
    End Function
End Class
