Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um Estado.
''' </summary>
Public Class State
    Inherits ParentModel
    Private _Name As String = String.Empty
    Private _ShortName As String
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Public ReadOnly Property ShortName As String
        Get
            Return _ShortName
        End Get
    End Property
    Public Sub Clear()
        SetID(0)
        _Name = Nothing
        _ShortName = Nothing
    End Sub
    Public Function Load(Identity As Long) As State
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdStateSelect As New MySqlCommand(My.Resources.StateSelect, Con)
                CmdStateSelect.Parameters.AddWithValue("@id", Identity)
                CmdStateSelect.Parameters.AddWithValue("@shortname", Nothing)
                Using Adp As New MySqlDataAdapter(CmdStateSelect)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                End Using
                If TableResult.Rows.Count = 0 Then
                    Clear()
                ElseIf TableResult.Rows.Count = 1 Then
                    Clear()
                    SetID(TableResult.Rows(0).Item("id"))
                    _Name = TableResult.Rows(0).Item("name")
                    _ShortName = TableResult.Rows(0).Item("shortname")
                Else
                    Throw New Exception("Registro não encontrado.")
                End If
            End Using
        End Using
        Return Me
    End Function
    Public Shared Function GetID(ShotName As String) As Long
        Dim TableResult As DataTable
        Dim ReturnedID As Long
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdStateSelect As New MySqlCommand(My.Resources.StateSelect, Con)
                CmdStateSelect.Parameters.AddWithValue("@id", 0)
                CmdStateSelect.Parameters.AddWithValue("@shortname", ShotName)
                Using Adp As New MySqlDataAdapter(CmdStateSelect)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                End Using
                If TableResult.Rows.Count = 1 Then
                    ReturnedID = TableResult.Rows(0).Item("id")
                Else
                    ReturnedID = 0
                End If
            End Using
        End Using
        Return ReturnedID
    End Function
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
