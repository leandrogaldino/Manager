Imports System.IO
Imports ChinhDo.Transactions
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um produto.
''' </summary>
Public Class Product
    Inherits ParentModel
    Private _Shadow As Product
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Note As String
    Public Property InternalName As String
    Public Property Pictures As New List(Of ProductPicture)
    Public Property ProviderCodes As New List(Of ProductProviderCode)
    Public Property Codes As New List(Of ProductCode)
    Public Property Location As String
    Public Property Family As New ProductFamily
    Public Property Group As New ProductGroup
    Public Property Unit As New ProductUnit
    Public Property MinimumQuantity As Decimal
    Public Property MaximumQuantity As Decimal
    Public Property GrossWeight As Decimal
    Public Property NetWeight As Decimal
    Public Sub New()
        SetRoutine(Routine.Product)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        InternalName = Nothing
        Pictures = New List(Of ProductPicture)
        ProviderCodes = New List(Of ProductProviderCode)
        Codes = New List(Of ProductCode)
        Location = Nothing
        MinimumQuantity = 0
        MaximumQuantity = 0
        Unit = New ProductUnit
        Family = New ProductFamily
        Group = New ProductGroup
        GrossWeight = 0
        NetWeight = 0
        Note = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Product
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProduct As New MySqlCommand(My.Resources.ProductSelect, Con)
                    CmdProduct.Transaction = Tra
                    CmdProduct.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdProduct)
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
                        InternalName = TableResult.Rows(0).Item("internalname").ToString
                        Pictures = GetPictures(Tra)
                        ProviderCodes = GetProviderCodes(Tra)
                        Codes = GetCodes(Tra)
                        Location = TableResult.Rows(0).Item("location").ToString
                        MinimumQuantity = TableResult.Rows(0).Item("minimumquantity")
                        MaximumQuantity = TableResult.Rows(0).Item("maximumquantity")
                        Family = New ProductFamily().Load(TableResult.Rows(0).Item("familyid"), Tra, False)
                        Unit = New ProductUnit().Load(TableResult.Rows(0).Item("unitid"), Tra, False)
                        Group = New ProductGroup().Load(TableResult.Rows(0).Item("groupid"), Tra, False)
                        GrossWeight = TableResult.Rows(0).Item("grossweight")
                        NetWeight = TableResult.Rows(0).Item("netweight")
                        Note = TableResult.Rows(0).Item("note").ToString
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        _Shadow = Clone()
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Pictures.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        ProviderCodes.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        Codes.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Dim FileManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdProduct As New MySqlCommand(My.Resources.ProductDelete, Con)
                    CmdProduct.Parameters.AddWithValue("@id", ID)
                    CmdProduct.ExecuteNonQuery()
                    For Each p In Pictures
                        If File.Exists(p.Picture.OriginalFile) Then FileManager.Delete(p.Picture.OriginalFile)
                    Next p
                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub
    Private Sub Insert()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdProduct As New MySqlCommand(My.Resources.ProductInsert, Con)
                    CmdProduct.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdProduct.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProduct.Parameters.AddWithValue("@name", Name)
                    CmdProduct.Parameters.AddWithValue("@internalname", InternalName)
                    CmdProduct.Parameters.AddWithValue("@location", If(String.IsNullOrEmpty(Location), DBNull.Value, Location))
                    CmdProduct.Parameters.AddWithValue("@minimumquantity", MinimumQuantity)
                    CmdProduct.Parameters.AddWithValue("@maximumquantity", MaximumQuantity)
                    CmdProduct.Parameters.AddWithValue("@unitid", Unit.ID)
                    CmdProduct.Parameters.AddWithValue("@familyid", Family.ID)
                    CmdProduct.Parameters.AddWithValue("@groupid", Group.ID)
                    CmdProduct.Parameters.AddWithValue("@grossweight", GrossWeight)
                    CmdProduct.Parameters.AddWithValue("@netweight", NetWeight)
                    CmdProduct.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdProduct.Parameters.AddWithValue("@userid", User.ID)
                    CmdProduct.ExecuteNonQuery()
                    SetID(CmdProduct.LastInsertedId)
                End Using
                For Each Picture As ProductPicture In Pictures
                    Using CmdPicture As New MySqlCommand(My.Resources.ProductPictureInsert, Con)
                        CmdPicture.Parameters.AddWithValue("@productid", ID)
                        CmdPicture.Parameters.AddWithValue("@creation", Picture.Creation)
                        CmdPicture.Parameters.AddWithValue("@picturename", Path.GetFileName(Picture.Picture.CurrentFile))
                        CmdPicture.Parameters.AddWithValue("@caption", Picture.Caption)
                        CmdPicture.Parameters.AddWithValue("@userid", Picture.User.ID)
                        CmdPicture.ExecuteNonQuery()
                        Picture.SetID(CmdPicture.LastInsertedId)
                    End Using
                Next Picture
                For Each ProviderCode As ProductProviderCode In ProviderCodes
                    Using CmdProviderCode As New MySqlCommand(My.Resources.ProductProviderCodeInsert, Con)
                        CmdProviderCode.Parameters.AddWithValue("@productid", ID)
                        CmdProviderCode.Parameters.AddWithValue("@creation", ProviderCode.Creation)
                        CmdProviderCode.Parameters.AddWithValue("@ismainprovider", ProviderCode.IsMainProvider)
                        CmdProviderCode.Parameters.AddWithValue("@code", ProviderCode.Code)
                        CmdProviderCode.Parameters.AddWithValue("@providerid", ProviderCode.Provider.ID)
                        CmdProviderCode.Parameters.AddWithValue("@userid", ProviderCode.User.ID)
                        CmdProviderCode.ExecuteNonQuery()
                        ProviderCode.SetID(CmdProviderCode.LastInsertedId)
                    End Using
                Next ProviderCode
                For Each Code As ProductCode In Codes
                    Using CmdCode As New MySqlCommand(My.Resources.ProductCodeInsert, Con)
                        CmdCode.Parameters.AddWithValue("@productid", ID)
                        CmdCode.Parameters.AddWithValue("@creation", Code.Creation)
                        CmdCode.Parameters.AddWithValue("@name", Code.Name)
                        CmdCode.Parameters.AddWithValue("@code", Code.Code)
                        CmdCode.Parameters.AddWithValue("@userid", Code.User.ID)
                        CmdCode.ExecuteNonQuery()
                        Code.SetID(CmdCode.LastInsertedId)
                    End Using
                Next Code
            End Using
            For Each Picture As ProductPicture In Pictures
                Picture.Picture.Execute()
            Next Picture
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Dim FileManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdProduct As New MySqlCommand(My.Resources.ProductUpdate, Con)
                    CmdProduct.Parameters.AddWithValue("@id", ID)
                    CmdProduct.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProduct.Parameters.AddWithValue("@name", Name)
                    CmdProduct.Parameters.AddWithValue("@internalname", InternalName)
                    CmdProduct.Parameters.AddWithValue("@location", If(String.IsNullOrEmpty(Location), DBNull.Value, Location))
                    CmdProduct.Parameters.AddWithValue("@minimumquantity", MinimumQuantity)
                    CmdProduct.Parameters.AddWithValue("@maximumquantity", MaximumQuantity)
                    CmdProduct.Parameters.AddWithValue("@unitid", Unit.ID)
                    CmdProduct.Parameters.AddWithValue("@familyid", Family.ID)
                    CmdProduct.Parameters.AddWithValue("@groupid", Group.ID)
                    CmdProduct.Parameters.AddWithValue("@grossweight", GrossWeight)
                    CmdProduct.Parameters.AddWithValue("@netweight", NetWeight)
                    CmdProduct.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdProduct.Parameters.AddWithValue("@userid", User.ID)
                    CmdProduct.ExecuteNonQuery()
                End Using
                For Each Picture As ProductPicture In _Shadow.Pictures
                    If Not Pictures.Any(Function(x) x.ID = Picture.ID And x.ID > 0) Then
                        Using CmdPicture As New MySqlCommand(My.Resources.ProductPictureDelete, Con)
                            CmdPicture.Parameters.AddWithValue("@id", Picture.ID)
                            CmdPicture.ExecuteNonQuery()
                        End Using
                        If File.Exists(Picture.Picture.OriginalFile) Then
                            FileManager.Delete(Picture.Picture.OriginalFile)
                        End If
                    End If
                Next Picture
                For Each Picture As ProductPicture In Pictures
                    If Picture.ID = 0 Then
                        Using CmdPicture As New MySqlCommand(My.Resources.ProductPictureInsert, Con)
                            CmdPicture.Parameters.AddWithValue("@productid", ID)
                            CmdPicture.Parameters.AddWithValue("@creation", Picture.Creation)
                            CmdPicture.Parameters.AddWithValue("@picturename", Path.GetFileName(Picture.Picture.CurrentFile))
                            CmdPicture.Parameters.AddWithValue("@caption", Picture.Caption)
                            CmdPicture.Parameters.AddWithValue("@userid", Picture.User.ID)
                            CmdPicture.ExecuteNonQuery()
                            Picture.SetID(CmdPicture.LastInsertedId)
                        End Using
                    Else
                        Using CmdPicture As New MySqlCommand(My.Resources.ProductPictureUpdate, Con)
                            CmdPicture.Parameters.AddWithValue("@id", Picture.ID)
                            CmdPicture.Parameters.AddWithValue("@picturename", Path.GetFileName(Picture.Picture.CurrentFile))
                            CmdPicture.Parameters.AddWithValue("@caption", Picture.Caption)
                            CmdPicture.Parameters.AddWithValue("@userid", Picture.User.ID)
                            CmdPicture.ExecuteNonQuery()
                        End Using
                    End If
                Next Picture
                For Each ProviderCode As ProductProviderCode In _Shadow.ProviderCodes
                    If Not ProviderCodes.Any(Function(x) x.ID = ProviderCode.ID And x.ID > 0) Then
                        Using CmdProdiderCode As New MySqlCommand(My.Resources.ProductProviderCodeDelete, Con)
                            CmdProdiderCode.Parameters.AddWithValue("@id", ProviderCode.ID)
                            CmdProdiderCode.ExecuteNonQuery()
                        End Using
                    End If
                Next ProviderCode
                For Each ProviderCode As ProductProviderCode In ProviderCodes
                    If ProviderCode.ID = 0 Then
                        Using CmdProviderCode As New MySqlCommand(My.Resources.ProductProviderCodeInsert, Con)
                            CmdProviderCode.Parameters.AddWithValue("@productid", ID)
                            CmdProviderCode.Parameters.AddWithValue("@creation", ProviderCode.Creation)
                            CmdProviderCode.Parameters.AddWithValue("@ismainprovider", ProviderCode.IsMainProvider)
                            CmdProviderCode.Parameters.AddWithValue("@code", ProviderCode.Code)
                            CmdProviderCode.Parameters.AddWithValue("@providerid", ProviderCode.Provider.ID)
                            CmdProviderCode.Parameters.AddWithValue("@userid", ProviderCode.User.ID)
                            CmdProviderCode.ExecuteNonQuery()
                            ProviderCode.SetID(CmdProviderCode.LastInsertedId)
                        End Using
                    Else
                        Using CmdProviderCode As New MySqlCommand(My.Resources.ProductProviderCodeUpdate, Con)
                            CmdProviderCode.Parameters.AddWithValue("@id", ProviderCode.ID)
                            CmdProviderCode.Parameters.AddWithValue("@ismainprovider", ProviderCode.IsMainProvider)
                            CmdProviderCode.Parameters.AddWithValue("@code", ProviderCode.Code)
                            CmdProviderCode.Parameters.AddWithValue("@providerid", ProviderCode.Provider.ID)
                            CmdProviderCode.Parameters.AddWithValue("@userid", ProviderCode.User.ID)
                            CmdProviderCode.ExecuteNonQuery()
                        End Using
                    End If
                Next ProviderCode
                For Each Code As ProductCode In _Shadow.Codes
                    If Not Codes.Any(Function(x) x.ID = Code.ID And x.ID > 0) Then
                        Using CmdCode As New MySqlCommand(My.Resources.ProductCodeDelete, Con)
                            CmdCode.Parameters.AddWithValue("@id", Code.ID)
                            CmdCode.ExecuteNonQuery()
                        End Using
                    End If
                Next Code
                For Each Code As ProductCode In Codes
                    If Code.ID = 0 Then
                        Using CmdCode As New MySqlCommand(My.Resources.ProductCodeInsert, Con)
                            CmdCode.Parameters.AddWithValue("@productid", ID)
                            CmdCode.Parameters.AddWithValue("@creation", Code.Creation)
                            CmdCode.Parameters.AddWithValue("@name", Code.Name)
                            CmdCode.Parameters.AddWithValue("@code", Code.Code)
                            CmdCode.Parameters.AddWithValue("@userid", Code.User.ID)
                            CmdCode.ExecuteNonQuery()
                            Code.SetID(CmdCode.LastInsertedId)
                        End Using
                    Else
                        Using CmdCode As New MySqlCommand(My.Resources.ProductCodeUpdate, Con)
                            CmdCode.Parameters.AddWithValue("@id", Code.ID)
                            CmdCode.Parameters.AddWithValue("@name", Code.Name)
                            CmdCode.Parameters.AddWithValue("@code", Code.Code)
                            CmdCode.Parameters.AddWithValue("@userid", Code.User.ID)
                            CmdCode.ExecuteNonQuery()
                        End Using
                    End If
                Next Code
            End Using
            For Each Picture As ProductPicture In Pictures
                Picture.Picture.Execute()
            Next Picture
            Transaction.Complete()
        End Using
    End Sub
    Private Function GetPictures(Transaction As MySqlTransaction) As List(Of ProductPicture)
        Dim TableResult As DataTable
        Dim Pictures As List(Of ProductPicture)
        Dim Picture As ProductPicture
        Using CmdPicture As New MySqlCommand(My.Resources.ProductPictureSelect, Transaction.Connection)
            CmdPicture.Transaction = Transaction
            CmdPicture.Parameters.AddWithValue("@productid", ID)
            Using Adp As New MySqlDataAdapter(CmdPicture)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Pictures = New List(Of ProductPicture)
                For Each Row As DataRow In TableResult.Rows
                    Picture = New ProductPicture With {
                        .Caption = Row.Item("caption").ToString
                    }
                    If Row.Item("picturename").ToString IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("picturename")) Then
                        Picture.Picture.SetCurrentFile(Path.Combine(ApplicationPaths.ProductPictureDirectory, Row.Item("picturename").ToString), True)
                    End If
                    Picture.SetIsSaved(True)
                    Picture.SetID(Row.Item("id"))
                    Picture.SetCreation(Row.Item("creation"))
                    Pictures.Add(Picture)
                Next Row
            End Using
        End Using
        Return Pictures
    End Function
    Private Function GetProviderCodes(Transaction As MySqlTransaction) As List(Of ProductProviderCode)
        Dim TableResult As DataTable
        Dim ProviderCodes As List(Of ProductProviderCode)
        Dim ProviderCode As ProductProviderCode
        Using CmdProviderCode As New MySqlCommand(My.Resources.ProductProviderCodeSelect, Transaction.Connection)
            CmdProviderCode.Transaction = Transaction
            CmdProviderCode.Parameters.AddWithValue("@productid", ID)
            Using Adp As New MySqlDataAdapter(CmdProviderCode)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                ProviderCodes = New List(Of ProductProviderCode)
                For Each Row As DataRow In TableResult.Rows
                    ProviderCode = New ProductProviderCode With {
                        .IsMainProvider = Row.Item("ismainprovider"),
                        .Code = Row.Item("code").ToString,
                        .Provider = New Person().Load(Row.Item("providerid"), False)
                    }
                    ProviderCode.SetIsSaved(True)
                    ProviderCode.SetID(Row.Item("id"))
                    ProviderCode.SetCreation(Row.Item("creation"))
                    ProviderCodes.Add(ProviderCode)
                Next Row
            End Using
        End Using
        Return ProviderCodes
    End Function
    Private Function GetCodes(Transaction As MySqlTransaction) As List(Of ProductCode)
        Dim TableResult As DataTable
        Dim Codes As List(Of ProductCode)
        Dim Code As ProductCode
        Using CmdCode As New MySqlCommand(My.Resources.ProductCodeSelect, Transaction.Connection)
            CmdCode.Transaction = Transaction
            CmdCode.Parameters.AddWithValue("@productid", ID)
            Using Adp As New MySqlDataAdapter(CmdCode)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Codes = New List(Of ProductCode)
                For Each Row As DataRow In TableResult.Rows
                    Code = New ProductCode
                    Code.Name = Row.Item("name").ToString
                    Code.Code = Row.Item("code").ToString
                    Code.SetIsSaved(True)
                    Code.SetID(Row.Item("id"))
                    Code.SetCreation(Row.Item("creation"))
                    Codes.Add(Code)
                Next Row
            End Using
        End Using
        Return Codes
    End Function
    Public Shared Sub FillCodeDataGridView(ProductID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.ProductCodeDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@productid", ProductID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Using
            End Using
        End Using
    End Sub
    Public Shared Sub FillProviderCodeDataGridView(ProductID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.ProductProviderCodeDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@productid", ProductID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.AutoGenerateColumns = False
                    Dgv.Columns.Clear()
                    Dgv.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Principal", .HeaderText = "Principal", .DataPropertyName = "Principal", .CellTemplate = New DataGridViewCheckBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Fornecedor", .HeaderText = "Fornecedor", .DataPropertyName = "Fornecedor", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Código", .HeaderText = "Código", .DataPropertyName = "Código", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Using
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class