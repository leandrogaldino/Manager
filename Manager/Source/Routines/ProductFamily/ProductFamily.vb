Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma família de produtos.
''' </summary>
Public Class ProductFamily
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Sub New()
        SetRoutine(Routine.ProductFamily)
    End Sub
    Public Sub Clear()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        If LockInfo.IsLocked Then Unlock()
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
                SetID(TableResult.Rows(0).Item("id"))
                SetCreation(TableResult.Rows(0).Item("creation"))
                SetIsSaved(True)
                Status = TableResult.Rows(0).Item("statusid")
                Name = TableResult.Rows(0).Item("name").ToString
                LockInfo = GetLockInfo(Transaction)
                If LockMe And Not LockInfo.IsLocked Then Lock(Transaction)
            Else
                Throw New Exception("Registro não encontrado.")
            End If
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
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Using CmdProductFamilyDelete As New MySqlCommand(My.Resources.ProductFamilyDelete, Con, Tra)
                    CmdProductFamilyDelete.Parameters.AddWithValue("@id", ID)
                    CmdProductFamilyDelete.ExecuteNonQuery()
                    Clear()
                End Using
                Tra.Commit()
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
                    SetID(CmdProductFamilyInsert.LastInsertedId)
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
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ProductFamily With {
            .Name = Name,
            .Status = Status
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function

End Class
