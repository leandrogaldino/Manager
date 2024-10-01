Imports System.ComponentModel
Imports ControlLibrary
Imports MySql.Data.MySqlClient

Public Class RouteConverter
    Inherits StringConverter
    Public Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Dim Session = Locator.GetInstance(Of Session)
        Dim List As New List(Of String) From {""}
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.RouteFilterConverterSelect, Con)
                Con.Open()
                Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                    While Reader.Read()
                        List.Add(Reader("name"))
                    End While
                End Using
            End Using
        End Using
        Return New StandardValuesCollection(List)
    End Function
End Class
