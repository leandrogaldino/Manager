Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports ControlLibrary
''' <summary>
''' Representa o filtro do gerenciamento de visitas aos compressores.
''' </summary>
Public Class EvaluationManagementFilter
    <Browsable(False)>
    Public Property DataGridView As DataGridView
    <Browsable(False)>
    Public Property PropertyGrid As PropertyGrid
    <DisplayName("Rota")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Route As String
    <DisplayName("Cliente")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Customer As New PersonExpandable
    <DisplayName("Endereço")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Address As New PersonAddressExpandable
    <DisplayName("Compressor")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Compressor As New PersonCompressorExpandable
    <DisplayName("Próxima Visita")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property NextVisit As New DateExpandable
    Public Sub New(Dgv As DataGridView, Pg As PropertyGrid)
        DataGridView = Dgv
        PropertyGrid = Pg
        Pg.SelectedObject = Me
    End Sub
    Public Sub New()
    End Sub
    Public Overridable Function Filter() As Boolean
        Dim Table As New DataTable
        Dim Filtering As Boolean
        Dim SelectedRow As Long = 0
        Dim FirstRow As Long = 0
        If DataGridView IsNot Nothing Then
            If DataGridView.SelectedRows.Count = 1 Then
                SelectedRow = DataGridView.SelectedRows(0).Index
            End If
            FirstRow = DataGridView.FirstDisplayedScrollingRowIndex
        End If
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementFilter, Con)
                If Customer.ID <> Nothing Then Cmd.Parameters.AddWithValue("@personid", Customer.ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@personid", "%")
                If Customer.Document <> Nothing Then Cmd.Parameters.AddWithValue("@persondocument", Customer.Document) : Filtering = True Else Cmd.Parameters.AddWithValue("@persondocument", "%")
                If Customer.Name <> Nothing Then Cmd.Parameters.AddWithValue("@personname", Customer.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@personname", "%")
                If Address.ZipCode <> Nothing Then Cmd.Parameters.AddWithValue("@zipcode", Address.ZipCode) : Filtering = True Else Cmd.Parameters.AddWithValue("@zipcode", "%")
                If Address.Address <> Nothing Then Cmd.Parameters.AddWithValue("@address", Address.Address) : Filtering = True Else Cmd.Parameters.AddWithValue("@address", "%")
                If Address.City <> Nothing Then Cmd.Parameters.AddWithValue("@city", Address.City) : Filtering = True Else Cmd.Parameters.AddWithValue("@city", "%")
                If Address.State <> Nothing Then Cmd.Parameters.AddWithValue("@state", Address.State) : Filtering = True Else Cmd.Parameters.AddWithValue("@state", "%")
                If Compressor.Name <> Nothing Then Cmd.Parameters.AddWithValue("@compressorname", Compressor.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@compressorname", "%")
                If Compressor.SerialNumber <> Nothing Then Cmd.Parameters.AddWithValue("@serialnumber", Compressor.SerialNumber) : Filtering = True Else Cmd.Parameters.AddWithValue("@serialnumber", "%")
                If Compressor.Patrimony <> Nothing Then Cmd.Parameters.AddWithValue("@patrimony", Compressor.Patrimony) : Filtering = True Else Cmd.Parameters.AddWithValue("@patrimony", "%")
                If Compressor.Sector <> Nothing Then Cmd.Parameters.AddWithValue("@sector", Compressor.Sector) : Filtering = True Else Cmd.Parameters.AddWithValue("@sector", "%")
                If Route <> Nothing Then Cmd.Parameters.AddWithValue("@route", Route) : Filtering = True Else Cmd.Parameters.AddWithValue("@route", "%")
                If NextVisit.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@nextexchangei", NextVisit.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@nextexchangei", "0000-01-01")
                If NextVisit.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@nextexchangef", NextVisit.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@nextexchangef", "9999-12-31")
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(Table)
                    DataGridView.DataSource = Nothing
                    DataGridView.DataSource = Table
                End Using
            End Using
        End Using
        If DataGridView.Rows.Count > 0 Then
            If SelectedRow < DataGridView.Rows.Count Then
                DataGridView.Rows(SelectedRow).Selected = True
            ElseIf SelectedRow >= DataGridView.Rows.Count Then
                DataGridView.Rows(DataGridView.Rows.Count - 1).Selected = True
            End If
            If DataGridView.DisplayedRowCount(True) > 0 Then
                If FirstRow > 0 Then
                    If DataGridView.Rows.Count >= FirstRow Then
                        DataGridView.FirstDisplayedScrollingRowIndex = FirstRow
                    Else
                        DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.Rows.Count - 1
                    End If
                Else
                    DataGridView.FirstDisplayedScrollingRowIndex = 0
                End If
            End If
        End If
        Return Filtering
    End Function
    Public Sub FilterControlledSellable(EvaluationID As Long, Dgv As DataGridView, PartType As CompressorSellableControlType)
        Dim Table As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementControlledSellableFilter, Con)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Cmd.Parameters.AddWithValue("@controltypeid", PartType)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(Table)
                    Dgv.DataSource = Table
                    Dgv.Columns(0).HeaderText = "Item"
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(1).Visible = False
                    Dgv.Columns(2).Width = 120
                    Dgv.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).HeaderText = "Troca Anterior"
                    Dgv.Columns(3).Width = 120
                    Dgv.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(3).HeaderText = "Próx. Troca"
                End Using
            End Using
        End Using
    End Sub
    Public Function GetUnitNextChange(EvaluationID As Long) As Date
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementUnit, Con)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Return Cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    Public Sub Clean()
        Customer = New PersonExpandable
        Address = New PersonAddressExpandable
        Compressor = New PersonCompressorExpandable
        Route = Nothing
        NextVisit = New DateExpandable
    End Sub
End Class
