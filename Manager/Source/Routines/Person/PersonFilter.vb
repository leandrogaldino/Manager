Imports System.ComponentModel
Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa o filtro das pessoas.
''' </summary>
Public Class PersonFilter
    Private _Document As String
    <Browsable(False)>
    Public Property DataGridView As DataGridView
    <Browsable(False)>
    Public Property PropertyGrid As PropertyGrid
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property ID As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(SimpleStatusConverter))>
    Public Overridable Property Status As String
    <DisplayName("CPF/CNPJ")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Document As String
        Get
            Return _Document
        End Get
        Set(value As String)
            Dim Str As String
            If value <> Nothing Then
                Str = value.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")
                If IsNumeric(Str) Then
                    If Str.Length = 14 Then
                        Str = Str.Substring(0, 2) & "." & Str.Substring(2, 3) & "." & Str.Substring(5, 3) & "/" & Str.Substring(8, 4) & "-" & Str.Substring(12, 2)
                        _Document = Str
                    ElseIf Str.Length = 11 Then
                        Str = Str.Substring(0, 3) & "." & Str.Substring(3, 3) & "." & Str.Substring(6, 3) & "-" & Str.Substring(9, 2)
                        _Document = Str
                    Else
                        _Document = value
                    End If
                End If
            Else
                _Document = value
            End If
        End Set
    End Property
    <DisplayName("Nome/Nome Curto")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Name As String
    <DisplayName("Observação")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Overridable Property Note As String
    <DisplayName("Categoria")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Overridable Property Category As New PersonCategoryExpandable
    <DisplayName("Controla Manutenção")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Overridable Property ControlMaintenance As String
    <DisplayName("Endereço")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Address As New PersonAddressExpandable
    <DisplayName("Contato")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Contact As New PersonContactExpandable
    <DisplayName("Compressor")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Compressor As New PersonCompressorExpandable
    <DisplayName("Rota")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(RouteConverter))>
    Public Overridable Property Route As String
    Public Sub New(Dgv As DataGridView, Pg As PropertyGrid)
        DataGridView = Dgv
        PropertyGrid = Pg
        Pg.SelectedObject = Me
    End Sub
    Public Sub New()
    End Sub
    Public Overridable Function Filter() As Boolean
        Dim Session = Locator.GetInstance(Of Session)
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
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.PersonFilter, Con)
                If ID <> Nothing Then Cmd.Parameters.AddWithValue("@id", ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@id", "%")
                If Status <> Nothing Then Cmd.Parameters.AddWithValue("@statusid", If(Status = EnumHelper.GetEnumDescription(SimpleStatus.Active), CInt(SimpleStatus.Active), CInt(SimpleStatus.Inactive))) : Filtering = True Else Cmd.Parameters.AddWithValue("@statusid", "%")
                If Document <> Nothing Then Cmd.Parameters.AddWithValue("@document", Document) : Filtering = True Else Cmd.Parameters.AddWithValue("@document", "%")
                If Name <> Nothing Then Cmd.Parameters.AddWithValue("@name", Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@name", "%")
                If Note <> Nothing Then Cmd.Parameters.AddWithValue("@note", Note) : Filtering = True Else Cmd.Parameters.AddWithValue("@note", "%")
                If Route <> Nothing Then Cmd.Parameters.AddWithValue("@route", Route) : Filtering = True Else Cmd.Parameters.AddWithValue("@route", "%")
                If Category.IsCustomer <> Nothing Then Cmd.Parameters.AddWithValue("@iscustomer", Category.IsCustomer = "Sim") : Filtering = True Else Cmd.Parameters.AddWithValue("@iscustomer", "%")
                If Category.IsProvider <> Nothing Then Cmd.Parameters.AddWithValue("@isprovider", Category.IsProvider = "Sim") : Filtering = True Else Cmd.Parameters.AddWithValue("@isprovider", "%")
                If Category.IsEmployee <> Nothing Then Cmd.Parameters.AddWithValue("@isemployee", Category.IsEmployee = "Sim") : Filtering = True Else Cmd.Parameters.AddWithValue("@isemployee", "%")
                If Category.IsTechnician <> Nothing Then Cmd.Parameters.AddWithValue("@istechnician", Category.IsTechnician = "Sim") : Filtering = True Else Cmd.Parameters.AddWithValue("@istechnician", "%")
                If Category.IsCarrier <> Nothing Then Cmd.Parameters.AddWithValue("@iscarrier", Category.IsCarrier = "Sim") : Filtering = True Else Cmd.Parameters.AddWithValue("@iscarrier", "%")
                If ControlMaintenance <> Nothing Then Cmd.Parameters.AddWithValue("@controlmaintenance", ControlMaintenance = "Sim") : Filtering = True Else Cmd.Parameters.AddWithValue("@controlmaintenance", "%")
                If Address.ZipCode <> Nothing Then Cmd.Parameters.AddWithValue("@zipcode", Address.ZipCode) : Filtering = True Else Cmd.Parameters.AddWithValue("@zipcode", "%")
                If Address.Address <> Nothing Then Cmd.Parameters.AddWithValue("@address", Address.Address) : Filtering = True Else Cmd.Parameters.AddWithValue("@address", "%")
                If Address.City <> Nothing Then Cmd.Parameters.AddWithValue("@city", Address.City) : Filtering = True Else Cmd.Parameters.AddWithValue("@city", "%")
                If Address.State <> Nothing Then Cmd.Parameters.AddWithValue("@state", Address.State) : Filtering = True Else Cmd.Parameters.AddWithValue("@state", "%")
                If Contact.Name <> Nothing Then Cmd.Parameters.AddWithValue("@contactname", Contact.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@contactname", "%")
                If Contact.JobTitle <> Nothing Then Cmd.Parameters.AddWithValue("@contactjobtitle", Contact.JobTitle) : Filtering = True Else Cmd.Parameters.AddWithValue("@contactjobtitle", "%")
                If Contact.Phone <> Nothing Then Cmd.Parameters.AddWithValue("@contactphone", Contact.Phone) : Filtering = True Else Cmd.Parameters.AddWithValue("@contactphone", "%")
                If Contact.Email <> Nothing Then Cmd.Parameters.AddWithValue("@contactemail", Contact.Email) : Filtering = True Else Cmd.Parameters.AddWithValue("@contactemail", "%")
                If Compressor.Name <> Nothing Then Cmd.Parameters.AddWithValue("@compressorname", Compressor.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@compressorname", "%")
                If Compressor.SerialNumber <> Nothing Then Cmd.Parameters.AddWithValue("@compressorserialnumber", Compressor.SerialNumber) : Filtering = True Else Cmd.Parameters.AddWithValue("@compressorserialnumber", "%")
                If Compressor.Patrimony <> Nothing Then Cmd.Parameters.AddWithValue("@compressorpatrimony", Compressor.Patrimony) : Filtering = True Else Cmd.Parameters.AddWithValue("@compressorpatrimony", "%")
                If Compressor.Sector <> Nothing Then Cmd.Parameters.AddWithValue("@compressorsector", Compressor.Sector) : Filtering = True Else Cmd.Parameters.AddWithValue("@compressorsector", "%")
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
    Public Sub Clean()
        ID = Nothing
        Status = Nothing
        Document = Nothing
        Name = Nothing
        Note = Nothing
        Route = Nothing
        Category = New PersonCategoryExpandable
        Address = New PersonAddressExpandable
        Contact = New PersonContactExpandable
        Compressor = New PersonCompressorExpandable
    End Sub
End Class
