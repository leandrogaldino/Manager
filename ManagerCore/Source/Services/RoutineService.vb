Imports CoreSuite.Services
Public Class RoutineService
    Private ReadOnly _MySqlService As MySqlService
    Private ReadOnly _RoutineFields As String() = {"id", "name", "description", "isbiState", "istriState", "dependencyid"}

    Public Sub New(MySqlService As MySqlService)
        _MySqlService = MySqlService
    End Sub
    Public Function GetRoutine(ID As Long) As RoutineModel
        Dim Response As MySqlResponse = _MySqlService.Request.ExecuteSelect("routine", New MySqlSelectOptions With {
            .Columns = _RoutineFields.ToList(),
            .Where = $"id = {ID}"
        })
        If Response.Data.Count = 0 Then Return Nothing
        Dim Row As Dictionary(Of String, Object) = Response.Data(0)
        Dim Routine As New RoutineModel With {
            .ID = If(IsDBNull(Row("id")), 0, Convert.ToInt64(Row("id"))),
            .Name = If(IsDBNull(Row("name")), "", Row("name").ToString()),
            .Description = If(IsDBNull(Row("description")), "", Row("description").ToString()),
            .IsBiState = Not IsDBNull(Row("isbiState")) AndAlso Convert.ToBoolean(Row("isbiState")),
            .IsTriState = Not IsDBNull(Row("istriState")) AndAlso Convert.ToBoolean(Row("istriState")),
            .Dependency = If(IsDBNull(Row("dependencyid")), 0, Convert.ToInt64(Row("dependencyid")))
        }
        Return Routine
    End Function
    Public Function GetRoutine(Name As String) As RoutineModel
        Dim Response As MySqlResponse = _MySqlService.Request.ExecuteSelect("routine", New MySqlSelectOptions With {
            .Columns = _RoutineFields.ToList(),
            .Where = $"name = '{Name}'"
        })
        If Response.Data.Count = 0 Then Return Nothing
        Dim Row As Dictionary(Of String, Object) = Response.Data(0)
        Dim Routine As New RoutineModel With {
            .ID = If(IsDBNull(Row("id")), 0, Convert.ToInt64(Row("id"))),
            .Name = If(IsDBNull(Row("name")), "", Row("name").ToString()),
            .Description = If(IsDBNull(Row("description")), "", Row("description").ToString()),
            .IsBiState = Not IsDBNull(Row("isbiState")) AndAlso Convert.ToBoolean(Row("isbiState")),
            .IsTriState = Not IsDBNull(Row("istriState")) AndAlso Convert.ToBoolean(Row("istriState")),
            .Dependency = If(IsDBNull(Row("dependencyid")), 0, Convert.ToInt64(Row("dependencyid")))
        }
        Return Routine
    End Function
    Public Function GetRoutines() As List(Of RoutineModel)
        Dim Response As MySqlResponse = _MySqlService.Request.ExecuteSelect("routine", New MySqlSelectOptions With {
            .Columns = _RoutineFields.ToList()
        })
        Dim Routines As New List(Of RoutineModel)
        For Each Row As Dictionary(Of String, Object) In Response.Data
            Dim Routine As New RoutineModel With {
                .ID = If(IsDBNull(Row("id")), 0, Convert.ToInt64(Row("id"))),
                .Name = If(IsDBNull(Row("name")), "", Row("name").ToString()),
                .Description = If(IsDBNull(Row("description")), "", Row("description").ToString()),
                .IsBiState = Not IsDBNull(Row("isbiState")) AndAlso Convert.ToBoolean(Row("isbiState")),
                .IsTriState = Not IsDBNull(Row("istriState")) AndAlso Convert.ToBoolean(Row("istriState")),
                .Dependency = If(IsDBNull(Row("dependencyid")), 0, Convert.ToInt64(Row("dependencyid")))
            }
            Routines.Add(Routine)
        Next Row
        Return Routines
    End Function
End Class
