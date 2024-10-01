Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um grupo de produtos.
''' </summary>
Public Class ProductGroup
    Inherits ModelBase
    Private _IsSaved As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Sub New()
        _Routine = Routine.ProductGroup
    End Sub
    Public Sub Clear()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        Status = SimpleStatus.Active
        Name = Nothing
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As ProductGroup
        Dim TableResult As DataTable
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductGroupSelect As New MySqlCommand(My.Resources.ProductGroupSelect, Con)
                    CmdProductGroupSelect.Transaction = Tra
                    CmdProductGroupSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdProductGroupSelect)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                        Unlock(Tra)
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        Unlock(Tra)
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
    Public Function Load(Identity As Long, Transaction As MySqlTransaction, LockMe As Boolean) As ProductGroup
        Dim TableResult As DataTable
        Using CmdProductGroupSelect As New MySqlCommand(My.Resources.ProductGroupSelect, Transaction.Connection)
            CmdProductGroupSelect.Transaction = Transaction
            CmdProductGroupSelect.Parameters.AddWithValue("@id", Identity)
            Using Adp As New MySqlDataAdapter(CmdProductGroupSelect)
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
                LockInfo = GetLockInfo(Transaction)
                If LockMe And Not LockInfo.IsLocked Then Lock(Transaction)
                _IsSaved = True
            Else
                Throw New Exception("Registro não encontrado.")
            End If
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
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductGroupDelete As New MySqlCommand(My.Resources.ProductGroupDelete, Con)
                CmdProductGroupDelete.Parameters.AddWithValue("@id", ID)
                CmdProductGroupDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductGroupInsert As New MySqlCommand(My.Resources.ProductGroupInsert, Con)
                    CmdProductGroupInsert.Transaction = Tra
                    CmdProductGroupInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdProductGroupInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProductGroupInsert.Parameters.AddWithValue("@name", Name)
                    CmdProductGroupInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdProductGroupInsert.ExecuteNonQuery()
                    _ID = CmdProductGroupInsert.LastInsertedId
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductGroupUpdate As New MySqlCommand(My.Resources.ProductGroupUpdate, Con)
                CmdProductGroupUpdate.Parameters.AddWithValue("@id", ID)
                CmdProductGroupUpdate.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdProductGroupUpdate.Parameters.AddWithValue("@name", Name)
                CmdProductGroupUpdate.Parameters.AddWithValue("@userid", User.ID)
                CmdProductGroupUpdate.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
