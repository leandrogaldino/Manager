﻿Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma rota.
''' </summary>
Public Class Route
    Inherits ModelBase
    Private _IsSaved As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Sub New()
        _Routine = Routine.Route
    End Sub
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        Status = SimpleStatus.Active
        Name = Nothing
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Route
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdRouteSelect As New MySqlCommand(My.Resources.RouteSelect, Con)
                    CmdRouteSelect.Transaction = Tra
                    CmdRouteSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdRouteSelect)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        _ID = TableResult.Rows(0).Item("id")
                        _Creation = TableResult.Rows(0).Item("creation")
                        Status = TableResult.Rows(0).Item("statusid")
                        Name = TableResult.Rows(0).Item("name").ToString
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                        _IsSaved = True
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not _IsSaved Then
            Insert()
        Else
            Update()
        End If
        _IsSaved = True
    End Sub
    Public Sub Delete()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdRouteDelete As New MySqlCommand(My.Resources.RouteDelete, Con)
                CmdRouteDelete.Parameters.AddWithValue("@id", ID)
                CmdRouteDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdRouteInsert As New MySqlCommand(My.Resources.RouteInsert, Con)
                    CmdRouteInsert.Transaction = Tra
                    CmdRouteInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdRouteInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdRouteInsert.Parameters.AddWithValue("@name", Name)
                    CmdRouteInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdRouteInsert.ExecuteNonQuery()
                    _ID = CmdRouteInsert.LastInsertedId
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdInsert As New MySqlCommand(My.Resources.RouteUpdate, Con)
                CmdInsert.Parameters.AddWithValue("@id", ID)
                CmdInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdInsert.Parameters.AddWithValue("@name", Name)
                CmdInsert.Parameters.AddWithValue("@userid", User.ID)
                CmdInsert.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
