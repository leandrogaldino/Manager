Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma família de produtos.
''' </summary>
Public Class ProductFamily
    Inherits ModelBase
    Private _IsSaved As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Sub New()
        _Routine = Routine.ProductFamily
    End Sub
    Public Sub Clear()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        Status = SimpleStatus.Active
        Name = Nothing
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As ProductFamily
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductFamilySelect As New MySqlCommand(My.Resources.ProductFamilySelect, Con)
                    CmdProductFamilySelect.Transaction = Tra
                    CmdProductFamilySelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdProductFamilySelect)
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
    Public Function Load(Identity As Long, Transaction As MySqlTransaction, LockMe As Boolean) As ProductFamily
        Dim TableResult As DataTable
        Using CmdProductFamilySelect As New MySqlCommand(My.Resources.ProductFamilySelect, Transaction.Connection)
            CmdProductFamilySelect.Transaction = Transaction
            CmdProductFamilySelect.Parameters.AddWithValue("@id", Identity)
            Using Adp As New MySqlDataAdapter(CmdProductFamilySelect)
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
            Using CmdProductFamilyDelete As New MySqlCommand(My.Resources.ProductFamilyDelete, Con)
                CmdProductFamilyDelete.Parameters.AddWithValue("@id", ID)
                CmdProductFamilyDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductFamilyInsert As New MySqlCommand(My.Resources.ProductFamilyInsert, Con)
                    CmdProductFamilyInsert.Transaction = Tra
                    CmdProductFamilyInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdProductFamilyInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProductFamilyInsert.Parameters.AddWithValue("@name", Name)
                    CmdProductFamilyInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdProductFamilyInsert.ExecuteNonQuery()
                    _ID = CmdProductFamilyInsert.LastInsertedId
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductFamilyInsert As New MySqlCommand(My.Resources.ProductFamilyUpdate, Con)
                CmdProductFamilyInsert.Parameters.AddWithValue("@id", ID)
                CmdProductFamilyInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdProductFamilyInsert.Parameters.AddWithValue("@name", Name)
                CmdProductFamilyInsert.Parameters.AddWithValue("@userid", User.ID)
                CmdProductFamilyInsert.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
