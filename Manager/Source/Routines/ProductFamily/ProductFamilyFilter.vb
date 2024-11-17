Imports System.ComponentModel
Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa o filtro das famílias de item.
''' </summary>
Public Class ProductFamilyFilter
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
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Nome")>
    Public Property Name As String
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
            Using Cmd As New MySqlCommand(My.Resources.ProductFamilyFilter, Con)
                If ID <> Nothing Then Cmd.Parameters.AddWithValue("@id", ID) : Filtering = True Else Cmd.Parameters.AddWithValue("@id", "%")
                If Status <> Nothing Then Cmd.Parameters.AddWithValue("@statusid", If(Status = EnumHelper.GetEnumDescription(SimpleStatus.Active), CInt(SimpleStatus.Active), CInt(SimpleStatus.Inactive))) : Filtering = True Else Cmd.Parameters.AddWithValue("@statusid", "%")
                If Name <> Nothing Then Cmd.Parameters.AddWithValue("@name", Name) : Filtering = True Else Cmd.Parameters.AddWithValue("@name", "%")
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
        Name = Nothing
    End Sub
End Class
