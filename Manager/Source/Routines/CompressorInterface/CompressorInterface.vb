Imports ControlLibrary
Imports MySql.Data.MySqlClient

''' <summary>
''' Representa um modelo de interface de um compressor.
''' </summary>
Public Class CompressorInterface
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property ProductID As Long
    Public Property ProductName As String
    Public Property Product As New Lazy(Of Product)

    Public Sub New()
        SetRoutine(Routine.ProductUnit)
    End Sub
    Public Sub Clear()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        ProductID = 0
        ProductName = Nothing
        Product = New Lazy(Of Product)
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As CompressorInterface
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.CompressorInterfaceSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                        Unlock(Tra)
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        Unlock(Tra)
                        SetID(Convert.ToInt64(TableResult.Rows(0).Item("id")))
                        SetCreation(Convert.ToDateTime(TableResult.Rows(0).Item("creation")))
                        SetIsSaved(True)
                        Status = Convert.ToInt32(TableResult.Rows(0).Item("statusid"))
                        Name = Convert.ToString(TableResult.Rows(0).Item("name"))
                        ProductID = Convert.ToInt64(TableResult.Rows(0).Item("productid"))
                        ProductName = Convert.ToString(TableResult.Rows(0).Item("productname"))
                        Product = New Lazy(Of Product)(Function() New Product().Load(ProductID, False))
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
    Public Function Load(Identity As Long, Transaction As MySqlTransaction, LockMe As Boolean) As CompressorInterface
        Dim TableResult As DataTable
        Using CmdProductUnitSelect As New MySqlCommand(My.Resources.CompressorInterfaceSelect, Transaction.Connection)
            CmdProductUnitSelect.Transaction = Transaction
            CmdProductUnitSelect.Parameters.AddWithValue("@id", Identity)
            Using Adp As New MySqlDataAdapter(CmdProductUnitSelect)
                TableResult = New DataTable
                Adp.Fill(TableResult)
            End Using
            If TableResult.Rows.Count = 0 Then
                Clear()
            ElseIf TableResult.Rows.Count = 1 Then
                Clear()
                Unlock(Transaction)
                SetID(Convert.ToInt64(TableResult.Rows(0).Item("id")))
                SetCreation(Convert.ToDateTime(TableResult.Rows(0).Item("creation")))
                SetIsSaved(True)
                Status = Convert.ToInt32(TableResult.Rows(0).Item("statusid"))
                Name = Convert.ToString(TableResult.Rows(0).Item("name"))
                ProductID = Convert.ToInt64(TableResult.Rows(0).Item("productid"))
                ProductName = Convert.ToString(TableResult.Rows(0).Item("productname"))
                Product = New Lazy(Of Product)(Function() New Product().Load(ProductID, False))
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
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Using CmdProductUnitDelete As New MySqlCommand(My.Resources.CompressorInterfaceDelete, Con, Tra)
                    CmdProductUnitDelete.Parameters.AddWithValue("@id", ID)
                    CmdProductUnitDelete.ExecuteNonQuery()
                    Clear()
                End Using
                Tra.Commit()
            End Using

        End Using
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductUnitInsert As New MySqlCommand(My.Resources.CompressorInterfaceInsert, Con)
                    CmdProductUnitInsert.Transaction = Tra
                    CmdProductUnitInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdProductUnitInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProductUnitInsert.Parameters.AddWithValue("@name", Name)
                    CmdProductUnitInsert.Parameters.AddWithValue("@productid", ProductID)
                    CmdProductUnitInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdProductUnitInsert.ExecuteNonQuery()
                    SetID(CmdProductUnitInsert.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductUnitUpdate As New MySqlCommand(My.Resources.CompressorInterfaceUpdate, Con)
                CmdProductUnitUpdate.Parameters.AddWithValue("@id", ID)
                CmdProductUnitUpdate.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdProductUnitUpdate.Parameters.AddWithValue("@name", Name)
                CmdProductUnitUpdate.Parameters.AddWithValue("@productid", ProductID)
                CmdProductUnitUpdate.Parameters.AddWithValue("@userid", User.ID)
                CmdProductUnitUpdate.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return Name
    End Function
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New CompressorInterface With {
            .Name = Name,
            .ProductID = ProductID,
            .ProductName = ProductName,
            .Status = Status,
            .Product = New Lazy(Of Product)(
                Function()
                    If Product.IsValueCreated Then
                        Return CType(Product.Value.Clone(), Product)
                    Else
                        Return New Product().Load(ProductID, False)
                    End If
                End Function
            )
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function
End Class
