Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports ControlLibrary
Public Class ProductFamilyConverter
    Inherits StringConverter
    Private _List As New List(Of String) From {""}
    Public Sub New()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand("SELECT name FROM productfamily ORDER BY name ASC;", Con)
                Con.Open()
                Using Reader As MySqlDataReader = Cmd.ExecuteReader
                    Do While Reader.Read
                        _List.Add(Reader.GetString(Reader.GetOrdinal("name")))
                    Loop
                End Using
            End Using
        End Using
    End Sub
    Public Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(_List)
    End Function
End Class
