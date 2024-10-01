Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports ControlLibrary
''' <summary>
''' Representa o filtro de e-mails enviados.
''' </summary>
Public Class EmailSentFilter
    <Browsable(False)>
    Public Property DataGridView As DataGridView
    <Browsable(False)>
    Public Property PropertyGrid As PropertyGrid
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("De")>
    Public Property From As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Assunto")>
    Public Property Subject As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Para")>
    Public Property [To] As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Cópia")>
    Public Property Cc As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Cópia Oculta")>
    Public Property Bcc As String
    <DisplayName("Data")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property [Date] As New DateExpandable
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
            Using Cmd As New MySqlCommand(My.Resources.EmailSentFilter, Con)
                Cmd.Parameters.AddWithValue("@ofuserid", Locator.GetInstance(Of Session).User.ID)
                If From <> Nothing Then Cmd.Parameters.AddWithValue("@fromemail", From) : Filtering = True Else Cmd.Parameters.AddWithValue("@fromemail", "%")
                If Subject <> Nothing Then Cmd.Parameters.AddWithValue("@subject", Subject) : Filtering = True Else Cmd.Parameters.AddWithValue("@subject", "%")
                If [To] <> Nothing Then Cmd.Parameters.AddWithValue("@toemail", [To]) : Filtering = True Else Cmd.Parameters.AddWithValue("@toemail", "%")
                If Cc <> Nothing Then Cmd.Parameters.AddWithValue("@ccemail", Cc) : Filtering = True Else Cmd.Parameters.AddWithValue("@ccemail", "%")
                If Bcc <> Nothing Then Cmd.Parameters.AddWithValue("@bccemail", Bcc) : Filtering = True Else Cmd.Parameters.AddWithValue("@bccemail", "%")
                If [Date].InitialDate <> Nothing Then Cmd.Parameters.AddWithValue("@datei", [Date].InitialDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@datei", "0001-01-01")
                If [Date].FinalDate <> Nothing Then Cmd.Parameters.AddWithValue("@datef", [Date].FinalDate.ToString("yyyy-MM-dd")) : Filtering = True Else Cmd.Parameters.AddWithValue("@datef", "9999-12-31")
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
        From = Nothing
        Subject = Nothing
        [To] = Nothing
        Cc = Nothing
        Bcc = Nothing
        [Date] = New DateExpandable
    End Sub
End Class
