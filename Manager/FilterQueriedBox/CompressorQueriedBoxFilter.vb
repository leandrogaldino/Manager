Imports System.ComponentModel
Imports ControlLibrary.Utility
Public Class CompressorQueriedBoxFilter
    Inherits CompressorFilter
    <Browsable(False)>
    Overrides Property Status As String
    Public Overrides Function Filter() As Boolean
        Status = GetEnumDescription(SimpleStatus.Active)
        Return MyBase.Filter()
    End Function
End Class
