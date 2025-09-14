Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um compressor.
''' </summary>
Public Class Compressor
    Inherits ParentModel

    Private _Shadow As Compressor
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property ManufacturerID As Long
    Public Property ManufacturerName As String
    Public Property Manufacturer As New Lazy(Of Person)
    Public Property WorkedHourSellables As New List(Of CompressorSellable)
    Public Property ElapsedDaySellables As New List(Of CompressorSellable)
    Public Sub New()
        SetRoutine(Routine.Compressor)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        ManufacturerID = 0
        ManufacturerName = String.Empty
        Manufacturer = New Lazy(Of Person)
        WorkedHourSellables = New List(Of CompressorSellable)
        ElapsedDaySellables = New List(Of CompressorSellable)
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Compressor
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCompressor As New MySqlCommand(My.Resources.CompressorSelect, Con, Tra)
                    CmdCompressor.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdCompressor)
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
                        Status = Convert.ToInt32(TableResult.Rows(0).Item("statusid"))
                        Name = Convert.ToString(TableResult.Rows(0).Item("name"))
                        ManufacturerID = Convert.ToInt32(TableResult.Rows(0).Item("manufacturerid"))
                        ManufacturerName = Convert.ToString(TableResult.Rows(0).Item("manufacturername"))
                        Manufacturer = New Lazy(Of Person)(Function() New Person().Load(ManufacturerID, False))
                        WorkedHourSellables = GetSellables(Tra, CompressorSellableControlType.WorkedHour)
                        ElapsedDaySellables = GetSellables(Tra, CompressorSellableControlType.ElapsedDay)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    ElseIf TableResult.Rows.Count > 1 Then
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
        WorkedHourSellables.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        ElapsedDaySellables.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                WorkedHourSellables.ForEach(Sub(x) x.UpdateUser(Con, Tra))
                ElapsedDaySellables.ForEach(Sub(x) x.UpdateUser(Con, Tra))
                Using CmdCompressor As New MySqlCommand(My.Resources.CompressorDelete, Con, Tra)
                    CmdCompressor.Parameters.AddWithValue("@id", ID)
                    CmdCompressor.ExecuteNonQuery()
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
                Using CmdCompressor As New MySqlCommand(My.Resources.CompressorInsert, Con, Tra)
                    CmdCompressor.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdCompressor.Parameters.AddWithValue("@statusid", Convert.ToInt32(Status))
                    CmdCompressor.Parameters.AddWithValue("@manufacturerid", If(ManufacturerID > 0, ManufacturerID, DBNull.Value))
                    CmdCompressor.Parameters.AddWithValue("@name", Name)
                    CmdCompressor.Parameters.AddWithValue("@userid", User.ID)
                    CmdCompressor.ExecuteNonQuery()
                    SetID(CmdCompressor.LastInsertedId)
                End Using
                For Each WorkedHourSellable As CompressorSellable In WorkedHourSellables
                    Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.CompressorSellableInsert, Con, Tra)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@compressorid", ID)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@statusid", Convert.ToInt32(WorkedHourSellable.Status))
                        CmdWorkedHourSellable.Parameters.AddWithValue("@controltypeid", Convert.ToInt32(WorkedHourSellable.SellableControlType))
                        CmdWorkedHourSellable.Parameters.AddWithValue("@productid", If(WorkedHourSellable.SellableType = SellableType.Product, WorkedHourSellable.SellableID, DBNull.Value))
                        CmdWorkedHourSellable.Parameters.AddWithValue("@serviceid", If(WorkedHourSellable.SellableType = SellableType.Service, WorkedHourSellable.SellableID, DBNull.Value))
                        CmdWorkedHourSellable.Parameters.AddWithValue("@quantity", WorkedHourSellable.Quantity)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                        CmdWorkedHourSellable.ExecuteNonQuery()
                        WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                    End Using
                Next WorkedHourSellable
                For Each ElapsedDaySellable As CompressorSellable In ElapsedDaySellables
                    Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.CompressorSellableInsert, Con, Tra)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@compressorid", ID)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@statusid", Convert.ToInt32(ElapsedDaySellable.Status))
                        CmdElapsedDaySellable.Parameters.AddWithValue("@controltypeid", ElapsedDaySellable.SellableControlType)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@productid", If(ElapsedDaySellable.SellableType = SellableType.Product, ElapsedDaySellable.SellableID, DBNull.Value))
                        CmdElapsedDaySellable.Parameters.AddWithValue("@serviceid", If(ElapsedDaySellable.SellableType = SellableType.Service, ElapsedDaySellable.SellableID, DBNull.Value))
                        CmdElapsedDaySellable.Parameters.AddWithValue("@quantity", ElapsedDaySellable.Quantity)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                        CmdElapsedDaySellable.ExecuteNonQuery()
                        ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                    End Using
                Next ElapsedDaySellable
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCompressor As New MySqlCommand(My.Resources.CompressorUpdate, Con, Tra)
                    CmdCompressor.Parameters.AddWithValue("@id", ID)
                    CmdCompressor.Parameters.AddWithValue("@statusid", Convert.ToInt32(Status))
                    CmdCompressor.Parameters.AddWithValue("@manufacturerid", If(ManufacturerID > 0, ManufacturerID, DBNull.Value))
                    CmdCompressor.Parameters.AddWithValue("@name", Name)
                    CmdCompressor.Parameters.AddWithValue("@userid", User.ID)
                    CmdCompressor.ExecuteNonQuery()
                End Using
                For Each WorkedHourSellable As CompressorSellable In _Shadow.WorkedHourSellables
                    If Not WorkedHourSellables.Any(Function(x) x.ID = WorkedHourSellable.ID And x.ID > 0) Then
                        Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.CompressorSellableDelete, Con, Tra)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@id", WorkedHourSellable.ID)
                            CmdWorkedHourSellable.ExecuteNonQuery()
                        End Using
                    End If
                Next WorkedHourSellable
                For Each WorkedHourSellable As CompressorSellable In WorkedHourSellables
                    If WorkedHourSellable.ID = 0 Then
                        Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.CompressorSellableInsert, Con, Tra)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@compressorid", ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@statusid", Convert.ToInt32(WorkedHourSellable.Status))
                            CmdWorkedHourSellable.Parameters.AddWithValue("@controltypeid", WorkedHourSellable.SellableControlType)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@productid", If(WorkedHourSellable.SellableType = SellableType.Product, WorkedHourSellable.SellableID, DBNull.Value))
                            CmdWorkedHourSellable.Parameters.AddWithValue("@serviceid", If(WorkedHourSellable.SellableType = SellableType.Service, WorkedHourSellable.SellableID, DBNull.Value))
                            CmdWorkedHourSellable.Parameters.AddWithValue("@quantity", WorkedHourSellable.Quantity)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                            CmdWorkedHourSellable.ExecuteNonQuery()
                            WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                        End Using
                    Else
                        Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.CompressorSellableUpdate, Con, Tra)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@id", WorkedHourSellable.ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@statusid", Convert.ToInt32(WorkedHourSellable.Status))
                            CmdWorkedHourSellable.Parameters.AddWithValue("@productid", If(WorkedHourSellable.SellableType = SellableType.Product, WorkedHourSellable.SellableID, DBNull.Value))
                            CmdWorkedHourSellable.Parameters.AddWithValue("@serviceid", If(WorkedHourSellable.SellableType = SellableType.Service, WorkedHourSellable.SellableID, DBNull.Value))
                            CmdWorkedHourSellable.Parameters.AddWithValue("@quantity", WorkedHourSellable.Quantity)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                            CmdWorkedHourSellable.ExecuteNonQuery()
                        End Using
                    End If
                Next WorkedHourSellable
                For Each ElapsedDaySellable As CompressorSellable In _Shadow.ElapsedDaySellables
                    If Not ElapsedDaySellables.Any(Function(x) x.ID = ElapsedDaySellable.ID And x.ID > 0) Then
                        Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.CompressorSellableDelete, Con, Tra)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@id", ElapsedDaySellable.ID)
                            CmdElapsedDaySellable.ExecuteNonQuery()
                        End Using
                    End If
                Next ElapsedDaySellable
                For Each ElapsedDaySellable As CompressorSellable In ElapsedDaySellables
                    If ElapsedDaySellable.ID = 0 Then
                        Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.CompressorSellableInsert, Con, Tra)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@compressorid", ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@statusid", Convert.ToInt32(ElapsedDaySellable.Status))
                            CmdElapsedDaySellable.Parameters.AddWithValue("@controltypeid", ElapsedDaySellable.SellableControlType)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@productid", If(ElapsedDaySellable.SellableType = SellableType.Product, ElapsedDaySellable.SellableID, DBNull.Value))
                            CmdElapsedDaySellable.Parameters.AddWithValue("@serviceid", If(ElapsedDaySellable.SellableType = SellableType.Service, ElapsedDaySellable.SellableID, DBNull.Value))
                            CmdElapsedDaySellable.Parameters.AddWithValue("@quantity", ElapsedDaySellable.Quantity)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                            CmdElapsedDaySellable.ExecuteNonQuery()
                            ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                        End Using
                    Else
                        Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.CompressorSellableUpdate, Con, Tra)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@id", ElapsedDaySellable.ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@statusid", Convert.ToInt32(ElapsedDaySellable.Status))
                            CmdElapsedDaySellable.Parameters.AddWithValue("@productid", If(ElapsedDaySellable.SellableType = SellableType.Product, ElapsedDaySellable.SellableID, DBNull.Value))
                            CmdElapsedDaySellable.Parameters.AddWithValue("@serviceid", If(ElapsedDaySellable.SellableType = SellableType.Service, ElapsedDaySellable.SellableID, DBNull.Value))
                            CmdElapsedDaySellable.Parameters.AddWithValue("@quantity", ElapsedDaySellable.Quantity)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                            CmdElapsedDaySellable.ExecuteNonQuery()
                        End Using
                    End If
                Next ElapsedDaySellable
                Tra.Commit()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
    Private Function GetSellables(Tra As MySqlTransaction, ControlType As CompressorSellableControlType) As List(Of CompressorSellable)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Dim WorkedHourSellables As List(Of CompressorSellable)
        Dim WorkedHourSellable As CompressorSellable
        Using CmdWorkedHour As New MySqlCommand(My.Resources.CompressorSellableSelect, Tra.Connection, Tra)
            CmdWorkedHour.Parameters.AddWithValue("@compressorid", ID)
            CmdWorkedHour.Parameters.AddWithValue("@controltypeid", ControlType)
            Using Adp As New MySqlDataAdapter(CmdWorkedHour)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                WorkedHourSellables = New List(Of CompressorSellable)
                For Each Row As DataRow In TableResult.Rows
                    WorkedHourSellable = New CompressorSellable(Row.Item("controltypeid")) With {
                            .Status = Row.Item("statusid"),
                            .Code = Row.Item("code"),
                            .Name = Row.Item("name"),
                            .SellableID = If(Row.Item("productid") IsNot DBNull.Value, Row.Item("productid"), Row.Item("serviceid")),
                            .SellableType = Row.Item("sellabletypeid"),
                            .Sellable = New Lazy(Of Sellable)(Function()
                                                                  If .SellableType = SellableType.Product Then
                                                                      Return New Product().Load(Row.Item("productid"), False)
                                                                  Else
                                                                      Return New Service().Load(Row.Item("serviceid"), False)
                                                                  End If
                                                              End Function),
                            .Quantity = Row.Item("quantity")
                        }
                    WorkedHourSellable.SetID(Row.Item("id"))
                    WorkedHourSellable.SetCreation(Row.Item("creation"))
                    WorkedHourSellable.SetIsSaved(True)
                    WorkedHourSellables.Add(WorkedHourSellable)
                Next Row
            End Using
        End Using
        Return WorkedHourSellables
    End Function
    Public Shared Sub FillSellableDataGridView(CompressorID As Long, Dgv As DataGridView, ControlType As CompressorSellableControlType)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.CompressorDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@compressorid", CompressorID)
                Cmd.Parameters.AddWithValue("@controltypeid", Convert.ToInt32(ControlType))
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.AutoGenerateColumns = False
                    Dgv.Columns.Clear()
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Código", .HeaderText = "Código", .DataPropertyName = "Código", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Produto/Serviço", .HeaderText = "Produto/Serviço", .DataPropertyName = "Produto/Serviço", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Qtd.", .HeaderText = "Qtd.", .DataPropertyName = "Qtd.", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Using
            End Using
        End Using
    End Sub
End Class
