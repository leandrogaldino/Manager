Imports System.ComponentModel
Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa o filtro dos CRMs.
''' </summary>
Public Class CrmFilter
    <Browsable(False)>
    Public Property DataGridView As DataGridView
    <Browsable(False)>
    Public Property PropertyGrid As PropertyGrid
    <DisplayName("Responsável")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(CrmResponsibleConverter))>
    Public Property Responsible As String = Locator.GetInstance(Of Session).User.Username
    <DisplayName("Assunto")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Overridable Property Subject As String
    <DisplayName("Cliente")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Customer As New PersonExpandable
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Overridable Property Status As New CrmStatusExpandable With {.Pending = "Sim", .Finished = "Não", .Lost = "Não"}
    <DisplayName("Últ. Contato")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property LastContact As New DateExpandable
    <DisplayName("Próx. Contato")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property NextContact As New DateExpandable With {.FinalDate = Today.AddDays(7)}

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
        If DataGridView IsNot Nothing Then
            If DataGridView.SelectedRows.Count = 1 Then
                SelectedRow = DataGridView.SelectedRows(0).Index
            End If
            FirstRow = DataGridView.FirstDisplayedScrollingRowIndex
        End If
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.CrmFilter, Con)
                If Status.Pending = "Sim" Or Status.Pending = Nothing Then StatusList.Add(CInt(EvaluationStatus.Disapproved))
                If Status.Finished = "Sim" Or Status.Finished = Nothing Then StatusList.Add(CInt(EvaluationStatus.Approved))
                If Status.Lost = "Sim" Or Status.Lost = Nothing Then StatusList.Add(CInt(EvaluationStatus.Rejected))
                Cmd.Parameters.AddWithValue("@statusid", String.Join(",", StatusList)) : Filtering = True
                If Responsible <> Nothing Then Cmd.Parameters.AddWithValue("@responsibleshortname", Responsible) : Filtering = True Else Cmd.Parameters.AddWithValue("@responsibleshortname", "%")
                If Customer.ID <> Nothing Then Cmd.Parameters.AddWithValue("@customerid", Customer.ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@customerid", "%")
                If Customer.Document <> Nothing Then Cmd.Parameters.AddWithValue("@customerdocument", Customer.Document) : Filtering = True Else Cmd.Parameters.AddWithValue("@customerdocument", "%")
                If Customer.Name <> Nothing Then Cmd.Parameters.AddWithValue("@customername", Customer.Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@customername", "%")
                If LastContact.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@lastcontacti", LastContact.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@lastcontacti", "0001-01-01")
                If LastContact.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@lastcontactf", LastContact.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@lastcontactf", "9999-12-31")
                If NextContact.InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@nextcontacti", NextContact.InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@nextcontacti", "0001-01-01")
                If NextContact.FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@nextcontactf", NextContact.FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@nextcontactf", "9999-12-31")
                If Subject <> Nothing Then Cmd.Parameters.AddWithValue("@subject", Subject) : Filtering = True Else Cmd.Parameters.AddWithValue("@subject", "%")
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
        Status = New CrmStatusExpandable
        Responsible = Nothing
        Customer = New PersonExpandable
        LastContact = New DateExpandable
        NextContact = New DateExpandable
        Subject = Nothing
    End Sub
End Class
