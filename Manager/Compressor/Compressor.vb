﻿Imports System.Reflection
Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um compressor.
''' </summary>
Public Class Compressor
    Inherits ModelBase
    Private _IsSaved As Boolean
    Private _ManufacturerID As Long
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Manufacturer As New Lazy(Of Person)(Function() New Person().Load(_ManufacturerID, False))
    Public Property PartsWorkedHour As New Lazy(Of OrdenedList(Of CompressorPart))(Function() GetPartsWorkedHour())
    Public Property PartsElapsedDay As New Lazy(Of OrdenedList(Of CompressorPart))(Function() GetPartsElapsedDay())
    Public Sub New()
        _Routine = Routine.Compressor
    End Sub
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        _ManufacturerID = 0
        Status = SimpleStatus.Active
        Name = Nothing
        Manufacturer = New Lazy(Of Person)(Function() New Person().Load(_ManufacturerID, False))
        PartsWorkedHour = New Lazy(Of OrdenedList(Of CompressorPart))(Function() GetPartsWorkedHour())
        PartsElapsedDay = New Lazy(Of OrdenedList(Of CompressorPart))(Function() GetPartsElapsedDay())
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Compressor
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCompressor As New MySqlCommand(My.Resources.CompressorSelect, Con)
                    CmdCompressor.Transaction = Tra
                    CmdCompressor.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdCompressor)
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
                        _ManufacturerID = TableResult.Rows(0).Item("manufacturerid")
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                        _IsSaved = True
                    ElseIf TableResult.Rows.Count > 1 Then
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
        PartsWorkedHour.Value.ToList().ForEach(Sub(x) x.IsSaved = True)
        PartsElapsedDay.Value.ToList().ForEach(Sub(x) x.IsSaved = True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdCompressor As New MySqlCommand(My.Resources.CompressorDelete, Con)
                CmdCompressor.Parameters.AddWithValue("@id", ID)
                CmdCompressor.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCompressor As New MySqlCommand(My.Resources.CompressorInsert, Con)
                    CmdCompressor.Transaction = Tra
                    CmdCompressor.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdCompressor.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdCompressor.Parameters.AddWithValue("@manufacturerid", Manufacturer.Value.ID)
                    CmdCompressor.Parameters.AddWithValue("@name", Name)
                    CmdCompressor.Parameters.AddWithValue("@userid", User.ID)
                    CmdCompressor.ExecuteNonQuery()
                    _ID = CmdCompressor.LastInsertedId
                End Using
                For Each PartWorkedHour As CompressorPart In PartsWorkedHour.Value
                    Using CmdPartWorkedHour As New MySqlCommand(My.Resources.CompressorPartInsert, Con)
                        CmdPartWorkedHour.Transaction = Tra
                        CmdPartWorkedHour.Parameters.AddWithValue("@compressorid", ID)
                        CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                        CmdPartWorkedHour.Parameters.AddWithValue("@statusid", CInt(PartWorkedHour.Status))
                        CmdPartWorkedHour.Parameters.AddWithValue("@parttypeid", PartWorkedHour.PartType)
                        CmdPartWorkedHour.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartWorkedHour.ItemName), DBNull.Value, PartWorkedHour.ItemName))
                        CmdPartWorkedHour.Parameters.AddWithValue("@productid", If(PartWorkedHour.Product.ID = 0, DBNull.Value, PartWorkedHour.Product.ID))
                        CmdPartWorkedHour.Parameters.AddWithValue("@quantity", PartWorkedHour.Quantity)
                        CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                        CmdPartWorkedHour.ExecuteNonQuery()
                        PartWorkedHour.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartWorkedHour, CmdPartWorkedHour.LastInsertedId)
                    End Using
                Next PartWorkedHour
                For Each PartElapsedDay As CompressorPart In PartsElapsedDay.Value
                    Using CmdPartElapsedDay As New MySqlCommand(My.Resources.CompressorPartInsert, Con)
                        CmdPartElapsedDay.Transaction = Tra
                        CmdPartElapsedDay.Parameters.AddWithValue("@compressorid", ID)
                        CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                        CmdPartElapsedDay.Parameters.AddWithValue("@statusid", CInt(PartElapsedDay.Status))
                        CmdPartElapsedDay.Parameters.AddWithValue("@parttypeid", PartElapsedDay.PartType)
                        CmdPartElapsedDay.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartElapsedDay.ItemName), DBNull.Value, PartElapsedDay.ItemName))
                        CmdPartElapsedDay.Parameters.AddWithValue("@productid", If(PartElapsedDay.Product.ID = 0, DBNull.Value, PartElapsedDay.Product.ID))
                        CmdPartElapsedDay.Parameters.AddWithValue("@quantity", PartElapsedDay.Quantity)
                        CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                        CmdPartElapsedDay.ExecuteNonQuery()
                        PartElapsedDay.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartElapsedDay, CmdPartElapsedDay.LastInsertedId)
                    End Using
                Next PartElapsedDay
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Shadow As Compressor = New Compressor().Load(ID, False)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCompressor As New MySqlCommand(My.Resources.CompressorUpdate, Con)
                    CmdCompressor.Transaction = Tra
                    CmdCompressor.Parameters.AddWithValue("@id", ID)
                    CmdCompressor.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdCompressor.Parameters.AddWithValue("@manufacturerid", Manufacturer.Value.ID)
                    CmdCompressor.Parameters.AddWithValue("@name", Name)
                    CmdCompressor.Parameters.AddWithValue("@userid", User.ID)
                    CmdCompressor.ExecuteNonQuery()
                End Using
                For Each PardWorkedHour As CompressorPart In Shadow.PartsWorkedHour.Value
                    If Not PartsWorkedHour.Value.Any(Function(x) x.ID = PardWorkedHour.ID And x.ID > 0) Then
                        Using CmdCompressorPart As New MySqlCommand(My.Resources.CompressorPartDelete, Con)
                            CmdCompressorPart.Transaction = Tra
                            CmdCompressorPart.Parameters.AddWithValue("@id", PardWorkedHour.ID)
                            CmdCompressorPart.ExecuteNonQuery()
                        End Using
                    End If
                Next PardWorkedHour
                For Each PartWorkedHour As CompressorPart In PartsWorkedHour.Value
                    If PartWorkedHour.ID = 0 Then
                        Using CmdPartWorkedHour As New MySqlCommand(My.Resources.CompressorPartInsert, Con)
                            CmdPartWorkedHour.Transaction = Tra
                            CmdPartWorkedHour.Parameters.AddWithValue("@compressorid", ID)
                            CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                            CmdPartWorkedHour.Parameters.AddWithValue("@statusid", CInt(PartWorkedHour.Status))
                            CmdPartWorkedHour.Parameters.AddWithValue("@parttypeid", PartWorkedHour.PartType)
                            CmdPartWorkedHour.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartWorkedHour.ItemName), DBNull.Value, PartWorkedHour.ItemName))
                            CmdPartWorkedHour.Parameters.AddWithValue("@productid", If(PartWorkedHour.Product.ID = 0, DBNull.Value, PartWorkedHour.Product.ID))
                            CmdPartWorkedHour.Parameters.AddWithValue("@quantity", PartWorkedHour.Quantity)
                            CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                            CmdPartWorkedHour.ExecuteNonQuery()
                            PartWorkedHour.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartWorkedHour, CmdPartWorkedHour.LastInsertedId)
                        End Using
                    Else
                        Using CmdPartWorkedHour As New MySqlCommand(My.Resources.CompressorPartUpdate, Con)
                            CmdPartWorkedHour.Transaction = Tra
                            CmdPartWorkedHour.Parameters.AddWithValue("@id", PartWorkedHour.ID)
                            CmdPartWorkedHour.Parameters.AddWithValue("@statusid", CInt(PartWorkedHour.Status))
                            CmdPartWorkedHour.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartWorkedHour.ItemName), DBNull.Value, PartWorkedHour.ItemName))
                            CmdPartWorkedHour.Parameters.AddWithValue("@productid", If(PartWorkedHour.Product.ID = 0, DBNull.Value, PartWorkedHour.Product.ID))
                            CmdPartWorkedHour.Parameters.AddWithValue("@quantity", PartWorkedHour.Quantity)
                            CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                            CmdPartWorkedHour.ExecuteNonQuery()
                        End Using
                    End If
                Next PartWorkedHour
                For Each PartElapsedDay As CompressorPart In Shadow.PartsElapsedDay.Value
                    If Not PartsElapsedDay.Value.Any(Function(x) x.ID = PartElapsedDay.ID And x.ID > 0) Then
                        Using CmdPartElapsedDay As New MySqlCommand(My.Resources.CompressorPartDelete, Con)
                            CmdPartElapsedDay.Transaction = Tra
                            CmdPartElapsedDay.Parameters.AddWithValue("@id", PartElapsedDay.ID)
                            CmdPartElapsedDay.ExecuteNonQuery()
                        End Using
                    End If
                Next PartElapsedDay
                For Each PartElapsedDay As CompressorPart In PartsElapsedDay.Value
                    If PartElapsedDay.ID = 0 Then
                        Using CmdPartElapsedDay As New MySqlCommand(My.Resources.CompressorPartInsert, Con)
                            CmdPartElapsedDay.Transaction = Tra
                            CmdPartElapsedDay.Parameters.AddWithValue("@compressorid", ID)
                            CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                            CmdPartElapsedDay.Parameters.AddWithValue("@statusid", CInt(PartElapsedDay.Status))
                            CmdPartElapsedDay.Parameters.AddWithValue("@parttypeid", PartElapsedDay.PartType)
                            CmdPartElapsedDay.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartElapsedDay.ItemName), DBNull.Value, PartElapsedDay.ItemName))
                            CmdPartElapsedDay.Parameters.AddWithValue("@productid", If(PartElapsedDay.Product.ID = 0, DBNull.Value, PartElapsedDay.Product.ID))
                            CmdPartElapsedDay.Parameters.AddWithValue("@quantity", PartElapsedDay.Quantity)
                            CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                            CmdPartElapsedDay.ExecuteNonQuery()
                            PartElapsedDay.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartElapsedDay, CmdPartElapsedDay.LastInsertedId)
                        End Using
                    Else
                        Using CmdPartElapsedDay As New MySqlCommand(My.Resources.CompressorPartUpdate, Con)
                            CmdPartElapsedDay.Transaction = Tra
                            CmdPartElapsedDay.Parameters.AddWithValue("@id", PartElapsedDay.ID)
                            CmdPartElapsedDay.Parameters.AddWithValue("@statusid", CInt(PartElapsedDay.Status))
                            CmdPartElapsedDay.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartElapsedDay.ItemName), DBNull.Value, PartElapsedDay.ItemName))
                            CmdPartElapsedDay.Parameters.AddWithValue("@productid", If(PartElapsedDay.Product.ID = 0, DBNull.Value, PartElapsedDay.Product.ID))
                            CmdPartElapsedDay.Parameters.AddWithValue("@quantity", PartElapsedDay.Quantity)
                            CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                            CmdPartElapsedDay.ExecuteNonQuery()
                        End Using
                    End If
                Next PartElapsedDay
                Tra.Commit()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
    Private Function GetPartsWorkedHour() As OrdenedList(Of CompressorPart)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Dim PartsWorkedHour As OrdenedList(Of CompressorPart)
        Dim PartWorkedHour As CompressorPart
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPartWorkedHour As New MySqlCommand(My.Resources.CompressorPartSelect, Con)
                CmdPartWorkedHour.Parameters.AddWithValue("@compressorid", ID)
                CmdPartWorkedHour.Parameters.AddWithValue("@parttypeid", CompressorPartType.WorkedHour)
                Using Adp As New MySqlDataAdapter(CmdPartWorkedHour)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                    PartsWorkedHour = New OrdenedList(Of CompressorPart)
                    For Each Row As DataRow In TableResult.Rows
                        PartWorkedHour = New CompressorPart(Row.Item("parttypeid"))
                        PartWorkedHour.Status = Row.Item("statusid")
                        PartWorkedHour.ItemName = Row.Item("itemname").ToString
                        PartWorkedHour.Product = New Product().Load(Row.Item("productid"), False)
                        PartWorkedHour.Quantity = Row.Item("quantity")
                        PartWorkedHour.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartWorkedHour, Row.Item("id"))
                        PartWorkedHour.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartWorkedHour, Row.Item("creation"))
                        PartWorkedHour.IsSaved = True
                        PartsWorkedHour.Add(PartWorkedHour)
                    Next Row
                End Using
            End Using
        End Using
        Return PartsWorkedHour
    End Function
    Private Function GetPartsElapsedDay() As OrdenedList(Of CompressorPart)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Dim PartsElapsedDay As OrdenedList(Of CompressorPart)
        Dim PartElapsedDay As CompressorPart
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPartElapsedDay As New MySqlCommand(My.Resources.CompressorPartSelect, Con)
                CmdPartElapsedDay.Parameters.AddWithValue("@compressorid", ID)
                CmdPartElapsedDay.Parameters.AddWithValue("@parttypeid", CompressorPartType.ElapsedDay)
                Using Adp As New MySqlDataAdapter(CmdPartElapsedDay)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                    PartsElapsedDay = New OrdenedList(Of CompressorPart)
                    For Each Row As DataRow In TableResult.Rows
                        PartElapsedDay = New CompressorPart(Row.Item("parttypeid"))
                        PartElapsedDay.Status = Row.Item("statusid")
                        PartElapsedDay.ItemName = Row.Item("itemname").ToString
                        PartElapsedDay.Product = New Product().Load(Row.Item("productid"), False)
                        PartElapsedDay.Quantity = Row.Item("quantity")
                        PartElapsedDay.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartElapsedDay, Row.Item("id"))
                        PartElapsedDay.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartElapsedDay, Row.Item("creation"))
                        PartElapsedDay.IsSaved = True
                        PartsElapsedDay.Add(PartElapsedDay)
                    Next Row
                End Using
            End Using
        End Using
        Return PartsElapsedDay
    End Function

    Public Shared Sub FillDataGridView(CompressorID As Long, Dgv As DataGridView, PartType As CompressorPartType)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.CompressorDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@compressorid", CompressorID)
                Cmd.Parameters.AddWithValue("@parttypeid", CInt(PartType))
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.AutoGenerateColumns = False
                    Dgv.Columns.Clear()
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Código", .HeaderText = "Código", .DataPropertyName = "Código", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Item", .HeaderText = "Item", .DataPropertyName = "Item", .CellTemplate = New DataGridViewTextBoxCell})
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
