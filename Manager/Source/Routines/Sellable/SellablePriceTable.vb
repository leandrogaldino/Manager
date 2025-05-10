Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma tabela de preços.
''' </summary>
Public Class SellablePriceTable
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Sub New()
        SetRoutine(Routine.SellablePriceTable)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As SellablePriceTable
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdSellablePriceTableSelect As New MySqlCommand(My.Resources.SellablePriceTableSelect, Con)
                    CmdSellablePriceTableSelect.Transaction = Tra
                    CmdSellablePriceTableSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdSellablePriceTableSelect)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        SetIsSaved(True)
                        Status = TableResult.Rows(0).Item("statusid")
                        Name = TableResult.Rows(0).Item("name").ToString
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
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
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdSellablePriceTableDelete As New MySqlCommand(My.Resources.SellablePriceTableDelete, Con)
                CmdSellablePriceTableDelete.Parameters.AddWithValue("@id", ID)
                CmdSellablePriceTableDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdSellablePriceTableInsert As New MySqlCommand(My.Resources.SellablePriceTableInsert, Con)
                    CmdSellablePriceTableInsert.Transaction = Tra
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@name", Name)
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdSellablePriceTableInsert.ExecuteNonQuery()
                    SetID(CmdSellablePriceTableInsert.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdSellablePriceTableUpdate As New MySqlCommand(My.Resources.SellablePriceTableUpdate, Con)
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@id", ID)
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@name", Name)
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@userid", User.ID)
                CmdSellablePriceTableUpdate.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
