Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports ControlLibrary
''' <summary>
''' Representa o filtro de avaliações de compressores.
''' </summary>
Public Class EvaluationFilter
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
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Overridable Property Status As New EvaluationStatusExpandable
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    <DisplayName("Fonte")>
    Public Overridable Property Source As New EvaluationSourceExpandable
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(EvaluationCallTypeConverter))>
    <DisplayName("Tipo")>
    Public Overridable Property CallType As String

    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Referência")>
    Public Property Reference As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Parecer Técnico")>
    Public Property TechnicalAdvice As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Observação")>
    Public Property Note As String
    <DisplayName("Técnico")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Technician As New PersonExpandable
    <DisplayName("Cliente")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Customer As New PersonExpandable
    <DisplayName("Compressor")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Compressor As New PersonCompressorExpandable
    <DisplayName("Horímetro")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Horimeter As New IntegerExpandable
    <DisplayName("Criação")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Creation As New DateExpandable
    <DisplayName("Data Avaliação")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property EvaluationDate As New DateExpandable
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
        Dim StatusList As New List(Of String)
        Dim SourceList As New List(Of String)
        If DataGridView IsNot Nothing Then
            If DataGridView.SelectedRows.Count = 1 Then
                SelectedRow = DataGridView.SelectedRows(0).Index
            End If
            FirstRow = DataGridView.FirstDisplayedScrollingRowIndex
        End If
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationFilter, Con)
                If ID <> Nothing Then Cmd.Parameters.AddWithValue("@id", ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@id", "%")
                If Status.Disapproved = "Sim" Or Status.Disapproved = Nothing Then StatusList.Add(CInt(EvaluationStatus.Disapproved))
                If Status.Approved = "Sim" Or Status.Approved = Nothing Then StatusList.Add(CInt(EvaluationStatus.Approved))
                If Status.Rejected = "Sim" Or Status.Rejected = Nothing Then StatusList.Add(CInt(EvaluationStatus.Rejected))
                If Status.Reviewed = "Sim" Or Status.Reviewed = Nothing Then StatusList.Add(CInt(EvaluationStatus.Reviewed))
                Cmd.Parameters.AddWithValue("@statusid", String.Join(",", StatusList)) : Filtering = True
                If Source.Manual = "Sim" Or Source.Manual = Nothing Then SourceList.Add(CInt(EvaluationSource.Manual))
                If Source.Automatic = "Sim" Or Source.Automatic = Nothing Then SourceList.Add(CInt(EvaluationSource.Automatic))
                If Source.Imported = "Sim" Or Source.Imported = Nothing Then SourceList.Add(CInt(EvaluationSource.Imported))
                Cmd.Parameters.AddWithValue("@sourceid", String.Join(",", SourceList)) : Filtering = True
                If CallType <> Nothing Then Cmd.Parameters.AddWithValue("@calltypeid", CInt(EnumHelper.GetEnumValue(Of CallType)(CallType.ToUpper))) : Filtering = True Else Cmd.Parameters.AddWithValue("@calltypeid", "%")
                If Reference <> Nothing Then Cmd.Parameters.AddWithValue("@reference", Reference) : Filtering = True Else Cmd.Parameters.AddWithValue("@reference", "%")
                If TechnicalAdvice <> Nothing Then Cmd.Parameters.AddWithValue("@technicaladvice", TechnicalAdvice) : Filtering = True Else Cmd.Parameters.AddWithValue("@technicaladvice", "%")
                If Note <> Nothing Then Cmd.Parameters.AddWithValue("@note", Note) : Filtering = True Else Cmd.Parameters.AddWithValue("@note", "%")
                If Technician.ID <> Nothing Then Cmd.Parameters.AddWithValue("@technicianid", Technician.ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@technicianid", "%")
                If Technician.Document <> Nothing Then Cmd.Parameters.AddWithValue("@techniciandocument", Technician.Document) : Filtering = True Else Cmd.Parameters.AddWithValue("@techniciandocument", "%")
                If Technician.Name <> Nothing Then Cmd.Parameters.AddWithValue("@technicianname", Technician.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@technicianname", "%")
                If Customer.ID <> Nothing Then Cmd.Parameters.AddWithValue("@customerid", Customer.ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@customerid", "%")
                If Customer.Document <> Nothing Then Cmd.Parameters.AddWithValue("@customerdocument", Customer.Document) : Filtering = True Else Cmd.Parameters.AddWithValue("@customerdocument", "%")
                If Customer.Name <> Nothing Then Cmd.Parameters.AddWithValue("@customername", Customer.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@customername", "%")
                If Compressor.Name <> Nothing Then Cmd.Parameters.AddWithValue("@compressorname", Compressor.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@compressorname", "%")
                If Compressor.SerialNumber <> Nothing Then Cmd.Parameters.AddWithValue("@serialnumber", Compressor.SerialNumber) : Filtering = True Else Cmd.Parameters.AddWithValue("@serialnumber", "%")
                If Compressor.Patrimony <> Nothing Then Cmd.Parameters.AddWithValue("@patrimony", Compressor.Patrimony) : Filtering = True Else Cmd.Parameters.AddWithValue("@patrimony", "%")
                If Compressor.Sector <> Nothing Then Cmd.Parameters.AddWithValue("@sector", Compressor.Sector) : Filtering = True Else Cmd.Parameters.AddWithValue("@sector", "%")
                If Horimeter.MinimumValue <> Nothing Then Cmd.Parameters.AddWithValue("@horimetermin", Horimeter.MinimumValue) : Filtering = True Else Cmd.Parameters.AddWithValue("@horimetermin", -9999999999)
                If Horimeter.MaximumValue <> Nothing Then Cmd.Parameters.AddWithValue("@horimetermax", Horimeter.MaximumValue) : Filtering = True Else Cmd.Parameters.AddWithValue("@horimetermax", 9999999999)
                If Creation.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@creationi", Creation.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@creationi", "0001-01-01")
                If Creation.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@creationf", Creation.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@creationf", "9999-12-31")
                If EvaluationDate.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@evaluationdatei", EvaluationDate.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@evaluationdatei", "0001-01-01")
                If EvaluationDate.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@evaluationdatef", EvaluationDate.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@evaluationdatef", "9999-12-31")
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
        Status = New EvaluationStatusExpandable
        Source = New EvaluationSourceExpandable
        CallType = Nothing
        Reference = Nothing
        Technician = New PersonExpandable
        Customer = New PersonExpandable
        Compressor = New PersonCompressorExpandable
        Horimeter = New IntegerExpandable
        Creation = New DateExpandable
        EvaluationDate = New DateExpandable
    End Sub
End Class
