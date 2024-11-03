Imports System.IO
Imports System.Reflection
Imports ChinhDo.Transactions
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um produto.
''' </summary>
Public Class Product
    Inherits ModelBase
    Private _IsSaved As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property InternalName As String
    Public Property Pictures As New OrdenedList(Of ProductPicture)
    Public Property ProviderCodes As New OrdenedList(Of ProductProviderCode)
    Public Property Codes As New OrdenedList(Of ProductCode)
    Public Property Prices As New OrdenedList(Of ProductPrice)
    Public Property Location As String
    Public Property Family As New ProductFamily
    Public Property Group As New ProductGroup
    Public Property Unit As New ProductUnit
    Public Property MinimumQuantity As Decimal
    Public Property MaximumQuantity As Decimal
    Public Property GrossWeight As Decimal
    Public Property NetWeight As Decimal
    Public Property Note As String
    Public Sub New()
        _Routine = Routine.Product
    End Sub
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        Status = SimpleStatus.Active
        Name = Nothing
        InternalName = Nothing
        Pictures = New OrdenedList(Of ProductPicture)
        ProviderCodes = New OrdenedList(Of ProductProviderCode)
        Codes = New OrdenedList(Of ProductCode)
        Prices = New OrdenedList(Of ProductPrice)
        Location = Nothing
        MinimumQuantity = 0
        MaximumQuantity = 0
        Unit = New ProductUnit
        Family = New ProductFamily
        Group = New ProductGroup
        GrossWeight = 0
        NetWeight = 0
        Note = Nothing
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
                        _ID = TableResult.Rows(0).Item("id")
                        _Creation = TableResult.Rows(0).Item("creation")
                        Status = TableResult.Rows(0).Item("statusid")
                        Name = TableResult.Rows(0).Item("name").ToString
                        InternalName = TableResult.Rows(0).Item("internalname").ToString
                        Pictures = GetPictures(Tra)
                        ProviderCodes = GetProviderCodes(Tra)
                        Codes = GetCodes(Tra)
                        Prices = GetPrices(Tra)
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
        Pictures.ToList().ForEach(Sub(x) x.IsSaved = True)
        ProviderCodes.ToList().ForEach(Sub(x) x.IsSaved = True)
        Codes.ToList().ForEach(Sub(x) x.IsSaved = True)
        Prices.ToList().ForEach(Sub(x) x.IsSaved = True)
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
                    _ID = CmdProduct.LastInsertedId
                End Using
                For Each Picture As ProductPicture In Pictures
                    Using CmdPicture As New MySqlCommand(My.Resources.ProductPictureInsert, Con)
                        CmdPicture.Parameters.AddWithValue("@productid", ID)
                        CmdPicture.Parameters.AddWithValue("@creation", Picture.Creation)
                        CmdPicture.Parameters.AddWithValue("@picturename", Path.GetFileName(Picture.Picture.CurrentFile))
                        CmdPicture.Parameters.AddWithValue("@caption", Picture.Caption)
                        CmdPicture.Parameters.AddWithValue("@userid", Picture.User.ID)
                        CmdPicture.ExecuteNonQuery()
                        Picture.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Picture, CmdPicture.LastInsertedId)
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
                        ProviderCode.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(ProviderCode, CmdProviderCode.LastInsertedId)
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
                        Code.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Code, CmdCode.LastInsertedId)
                    End Using
                Next Code
                For Each Price As ProductPrice In Prices
                    Using CmdCode As New MySqlCommand(My.Resources.ProductPriceInsert, Con)
                        CmdCode.Parameters.AddWithValue("@productid", ID)
                        CmdCode.Parameters.AddWithValue("@creation", Price.Creation)
                        CmdCode.Parameters.AddWithValue("@pricetableid", Price.PriceTable.ID)
                        CmdCode.Parameters.AddWithValue("@price", Price.Price)
                        CmdCode.Parameters.AddWithValue("@userid", Price.User.ID)
                        CmdCode.ExecuteNonQuery()
                        Price.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Price, CmdCode.LastInsertedId)
                    End Using
                Next Price
            End Using
            For Each Picture As ProductPicture In Pictures
                Picture.Picture.Execute()
            Next Picture
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Dim Shadow As Product = New Product().Load(ID, False)
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
                For Each Picture As ProductPicture In Shadow.Pictures
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
                            Picture.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Picture, CmdPicture.LastInsertedId)
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
                For Each ProviderCode As ProductProviderCode In Shadow.ProviderCodes
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
                            ProviderCode.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(ProviderCode, CmdProviderCode.LastInsertedId)
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
                For Each Code As ProductCode In Shadow.Codes
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
                            Code.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Code, CmdCode.LastInsertedId)
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
                For Each Price As ProductPrice In Shadow.Prices
                    If Not Prices.Any(Function(x) x.ID = Price.ID And x.ID > 0) Then
                        Using CmdPrice As New MySqlCommand(My.Resources.ProductPriceDelete, Con)
                            CmdPrice.Parameters.AddWithValue("@id", Price.ID)
                            CmdPrice.ExecuteNonQuery()
                        End Using
                    End If
                Next Price
                For Each Price As ProductPrice In Prices
                    If Price.ID = 0 Then
                        Using CmdPrice As New MySqlCommand(My.Resources.ProductPriceInsert, Con)
                            CmdPrice.Parameters.AddWithValue("@productid", ID)
                            CmdPrice.Parameters.AddWithValue("@creation", Price.Creation)
                            CmdPrice.Parameters.AddWithValue("@pricetableid", Price.PriceTable.ID)
                            CmdPrice.Parameters.AddWithValue("@price", Price.Price)
                            CmdPrice.Parameters.AddWithValue("@userid", Price.User.ID)
                            CmdPrice.ExecuteNonQuery()
                            Price.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Price, CmdPrice.LastInsertedId)
                        End Using
                    Else
                        Using CmdPrice As New MySqlCommand(My.Resources.ProductPriceUpdate, Con)
                            CmdPrice.Parameters.AddWithValue("@id", Price.ID)
                            CmdPrice.Parameters.AddWithValue("@pricetableid", Price.PriceTable.ID)
                            CmdPrice.Parameters.AddWithValue("@price", Price.Price)
                            CmdPrice.Parameters.AddWithValue("@userid", Price.User.ID)
                            CmdPrice.ExecuteNonQuery()
                        End Using
                    End If
                Next Price
            End Using
            For Each Picture As ProductPicture In Pictures
                Picture.Picture.Execute()
            Next Picture
            Transaction.Complete()
        End Using
    End Sub
    Private Function GetPictures(Transaction As MySqlTransaction) As OrdenedList(Of ProductPicture)
        Dim TableResult As DataTable
        Dim Pictures As OrdenedList(Of ProductPicture)
        Dim Picture As ProductPicture
        Using CmdPicture As New MySqlCommand(My.Resources.ProductPictureSelect, Transaction.Connection)
            CmdPicture.Transaction = Transaction
            CmdPicture.Parameters.AddWithValue("@productid", ID)
            Using Adp As New MySqlDataAdapter(CmdPicture)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Pictures = New OrdenedList(Of ProductPicture)
                For Each Row As DataRow In TableResult.Rows
                    Picture = New ProductPicture
                    If Row.Item("picturename").ToString IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("picturename")) Then
                        Picture.Picture.SetCurrentFile(Path.Combine(ApplicationPaths.ProductPictureDirectory, Row.Item("picturename").ToString), True)
                    End If
                    Picture.Caption = Row.Item("caption").ToString
                    Picture.IsSaved = True
                    Picture.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Picture, Row.Item("id"))
                    Picture.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Picture, Row.Item("creation"))
                    Pictures.Add(Picture)
                Next Row
            End Using
        End Using
        Return Pictures
    End Function
    Private Function GetProviderCodes(Transaction As MySqlTransaction) As OrdenedList(Of ProductProviderCode)
        Dim TableResult As DataTable
        Dim ProviderCodes As OrdenedList(Of ProductProviderCode)
        Dim ProviderCode As ProductProviderCode
        Using CmdProviderCode As New MySqlCommand(My.Resources.ProductProviderCodeSelect, Transaction.Connection)
            CmdProviderCode.Transaction = Transaction
            CmdProviderCode.Parameters.AddWithValue("@productid", ID)
            Using Adp As New MySqlDataAdapter(CmdProviderCode)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                ProviderCodes = New OrdenedList(Of ProductProviderCode)
                For Each Row As DataRow In TableResult.Rows
                    ProviderCode = New ProductProviderCode
                    ProviderCode.IsMainProvider = Row.Item("ismainprovider")
                    ProviderCode.Code = Row.Item("code").ToString
                    ProviderCode.Provider = New Person().Load(Row.Item("providerid"), False)
                    ProviderCode.IsSaved = True
                    ProviderCode.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(ProviderCode, Row.Item("id"))
                    ProviderCode.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(ProviderCode, Row.Item("creation"))
                    ProviderCodes.Add(ProviderCode)
                Next Row
            End Using
        End Using
        Return ProviderCodes
    End Function
    Private Function GetCodes(Transaction As MySqlTransaction) As OrdenedList(Of ProductCode)
        Dim TableResult As DataTable
        Dim Codes As OrdenedList(Of ProductCode)
        Dim Code As ProductCode
        Using CmdCode As New MySqlCommand(My.Resources.ProductCodeSelect, Transaction.Connection)
            CmdCode.Transaction = Transaction
            CmdCode.Parameters.AddWithValue("@productid", ID)
            Using Adp As New MySqlDataAdapter(CmdCode)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Codes = New OrdenedList(Of ProductCode)
                For Each Row As DataRow In TableResult.Rows
                    Code = New ProductCode
                    Code.Name = Row.Item("name").ToString
                    Code.Code = Row.Item("code").ToString
                    Code.IsSaved = True
                    Code.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Code, Row.Item("id"))
                    Code.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Code, Row.Item("creation"))
                    Codes.Add(Code)
                Next Row
            End Using
        End Using
        Return Codes
    End Function
    Private Function GetPrices(Transaction As MySqlTransaction) As OrdenedList(Of ProductPrice)
        Dim TableResult As DataTable
        Dim ProductPrices As OrdenedList(Of ProductPrice)
        Dim ProductPrice As ProductPrice
        Using CmdPrice As New MySqlCommand(My.Resources.ProductPriceSelect, Transaction.Connection)
            CmdPrice.Transaction = Transaction
            CmdPrice.Parameters.AddWithValue("@productid", ID)
            Using Adp As New MySqlDataAdapter(CmdPrice)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                ProductPrices = New OrdenedList(Of ProductPrice)
                For Each Row As DataRow In TableResult.Rows
                    ProductPrice = New ProductPrice
                    ProductPrice.PriceTable = New ProductPriceTable().Load(Row.Item("pricetableid"), False)
                    ProductPrice.Price = Row.Item("price")
                    ProductPrice.IsSaved = True
                    ProductPrice.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(ProductPrice, Row.Item("id"))
                    ProductPrice.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(ProductPrice, Row.Item("creation"))
                    ProductPrices.Add(ProductPrice)
                Next Row
            End Using
        End Using
        Return ProductPrices
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
    Public Shared Sub FillPriceDataGridView(ProductID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.ProductPriceDetailSelect, Con)
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
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class