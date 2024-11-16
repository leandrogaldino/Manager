Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Public Class DataGridViewLayout
    Inherits Component
    Public Event Loaded(sender As Object, e As EventArgs)
    Private _SaveLayout As Boolean
    Private _LoadLayout As Boolean
    Private _CmsPoint As Point
    Private _DataGridView As New DataGridView
    Private _CmsColumns As New ContextMenuStrip
    Public Property Routine As Routine
    Public Shared Property XmlDirectory As String
    Public Property DataGridView As DataGridView
        Get
            Return _DataGridView
        End Get
        Set(value As DataGridView)
            If _DataGridView IsNot Nothing Then
                RemoveHandler DataGridView.MouseDown, AddressOf DataGridView_MouseDown
                RemoveHandler DataGridView.MouseUp, AddressOf DataGridView_MouseUp
                RemoveHandler _CmsColumns.Closing, AddressOf CmsColumns_Closing
            End If
            _DataGridView = value
            AddHandler DataGridView.MouseDown, AddressOf DataGridView_MouseDown
            AddHandler DataGridView.MouseUp, AddressOf DataGridView_MouseUp
            AddHandler _CmsColumns.Closing, AddressOf CmsColumns_Closing
        End Set
    End Property
    Private Sub DataGridView_MouseDown(sender As Object, e As MouseEventArgs)
        Dim Click As DataGridView.HitTestInfo = DataGridView.HitTest(e.X, e.Y)
        If Click.Type = DataGridViewHitTestType.ColumnHeader And e.Button = MouseButtons.Right Then
            _SaveLayout = False
            _LoadLayout = True
            _CmsPoint = e.Location
        ElseIf Click.Type = DataGridViewHitTestType.ColumnHeader And e.Button = MouseButtons.Left Then
            _SaveLayout = True
            _LoadLayout = False
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DataGridView_MouseUp(sender As Object, e As MouseEventArgs)
        If _SaveLayout Then
            Save()
        End If
        If _LoadLayout Then
            Load()
            _CmsColumns.Show(DataGridView.PointToScreen(_CmsPoint))
        End If
        _SaveLayout = False
        _LoadLayout = False
    End Sub
    Private Sub CmsColumns_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs)
        If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then
            e.Cancel = True
        End If
    End Sub
    Private Sub BtnRestoreGridLayout_Click(sender As Object, e As EventArgs)
        _CmsColumns.Close()
        If File.Exists(XmlDirectory & "\" & Routine.ToString & ".xml") Then
            If File.Exists(XmlDirectory & "\" & Routine.ToString & ".xml") Then
                File.WriteAllText(XmlDirectory & "\" & Routine.ToString & ".xml", My.Resources.ResourceManager.GetString(Routine.ToString & "Grid"))
            End If
            Load()
        End If
    End Sub
    Private Sub BtnRemoveSort_Click(sender As Object, e As EventArgs)
        Dim Layout As XmlDocument
        _CmsColumns.Close()
        Layout = New XmlDocument
        Layout.Load(XmlDirectory & "\" & Routine.ToString & ".xml")
        Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/SortedColumn", Routine)).InnerText = -1
        Layout.Save(XmlDirectory & "\" & Routine.ToString & ".xml")
        CType(DataGridView.DataSource, DataTable).DefaultView.Sort = ""
        Load()
    End Sub
    Private Sub BtnColumn_CheckedChanged(sender As Object, e As EventArgs)
        If CType(CType(sender, ToolStripMenuItem).GetCurrentParent, ContextMenuStrip).Items.OfType(Of ToolStripMenuItem).Cast(Of ToolStripMenuItem).Where(Function(x) x.Checked).Count = 0 Then
            sender.checked = True
        End If
        DataGridView.Columns.Cast(Of DataGridViewColumn).Single(Function(x) x.HeaderText = sender.Text).Visible = sender.Checked
        Save()
    End Sub
    Public Sub Load()
        Dim Layout As XmlDocument
        Dim Index As Integer
        Dim Button As ToolStripMenuItem
        Dim Nodes As XmlNodeList
        Dim SortedColumn As Integer
        Dim SortDirection As Integer
        Dim SelectedRow As Long = 0
        Dim FirstRow As Long = 0
        _CmsColumns.Font = New Font("Century Gothic", 9.75, FontStyle.Regular)
        If File.Exists(XmlDirectory & "\" & Routine.ToString & ".xml") Then
            Layout = New XmlDocument
            Layout.Load(XmlDirectory & "\" & Routine.ToString & ".xml")
            Nodes = Layout.SelectNodes(String.Format("/Routine[@Id='{0}']/Column", Routine))
            For Each Node As XmlNode In Nodes
                Index = Node.Attributes.GetNamedItem("Index").Value
                DataGridView.Columns(Index).Visible = Node("Visible").InnerText
                DataGridView.Columns(Index).DisplayIndex = Node("DisplayIndex").InnerText
                DataGridView.Columns(Index).HeaderText = Node("Name").InnerText
                DataGridView.Columns(Index).Width = Node("Width").InnerText
            Next Node
            SortedColumn = Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/SortedColumn", Routine)).InnerText
            SortDirection = Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/SortDirection", Routine)).InnerText
            If SortedColumn > -1 Then
                If DataGridView IsNot Nothing Then
                    If DataGridView.SelectedRows.Count = 1 Then
                        SelectedRow = DataGridView.SelectedRows(0).Index
                    End If
                    FirstRow = DataGridView.FirstDisplayedScrollingRowIndex
                End If
                DataGridView.Sort(DataGridView.Columns(SortedColumn), SortDirection)
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
            End If
            _CmsColumns.Items.Clear()
            Button = New ToolStripMenuItem
            Button.Name = "BtnRestoreGridLayout"
            Button.Text = "Restaurar Colunas"
            _CmsColumns.Items.Add(Button)
            AddHandler Button.Click, AddressOf BtnRestoreGridLayout_Click
            Button = New ToolStripMenuItem
            Button.Name = "BtnRemoveSort"
            Button.Text = "Remover Classificação"
            _CmsColumns.Items.Add(Button)
            AddHandler Button.Click, AddressOf BtnRemoveSort_Click
            _CmsColumns.Items.Add(New ToolStripSeparator)
            For i = 0 To DataGridView.Columns.Count - 1
                Index = i
                If Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/Column[@Index='{1}']/Visible", Routine, DataGridView.Columns.Cast(Of DataGridViewColumn).First(Function(x) x.DisplayIndex = Index).Index)) IsNot Nothing Then
                    If Not Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/Column[@Index='{1}']", Routine, DataGridView.Columns.Cast(Of DataGridViewColumn).First(Function(x) x.DisplayIndex = Index).Index)).Attributes.Cast(Of XmlAttribute).Any(Function(x) x.Name = "ButtonState") Then
                        Button = New ToolStripMenuItem
                        Button.CheckOnClick = True
                        Button.Text = DataGridView.Columns.Cast(Of DataGridViewColumn).First(Function(x) x.DisplayIndex = Index).HeaderText
                        Button.Tag = DataGridView.Columns.Cast(Of DataGridViewColumn).First(Function(x) x.DisplayIndex = Index).Index
                        Button.Checked = Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/Column[@Index='{1}']/Visible", Routine, DataGridView.Columns.Cast(Of DataGridViewColumn).First(Function(x) x.DisplayIndex = Index).Index)).InnerText
                        AddHandler Button.CheckedChanged, AddressOf BtnColumn_CheckedChanged
                        _CmsColumns.Items.Add(Button)
                    End If
                End If
            Next i
        End If
        RaiseEvent Loaded(Me, EventArgs.Empty)
    End Sub
    Public Sub Save()
        Dim Layout As XmlDocument
        Dim Nodes As XmlNodeList
        Dim Index As Integer
        If File.Exists(XmlDirectory & "\" & Routine.ToString & ".xml") Then
            Layout = New XmlDocument
            Layout.Load(XmlDirectory & "\" & Routine.ToString & ".xml")
            Nodes = Layout.SelectNodes(String.Format("/Routine[@Id='{0}']/Column", Routine))
            For Each Node As XmlNode In Nodes
                Index = Node.Attributes.GetNamedItem("Index").Value
                Node("Visible").InnerText = DataGridView.Columns(Index).Visible
                Node("DisplayIndex").InnerText = DataGridView.Columns(Index).DisplayIndex
                Node("Name").InnerText = DataGridView.Columns(Index).HeaderText
                Node("Width").InnerText = DataGridView.Columns(Index).Width
            Next Node
            Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/SortedColumn", Routine)).InnerText = If(DataGridView.SortedColumn IsNot Nothing, DataGridView.SortedColumn.Index, -1)
            Layout.SelectSingleNode(String.Format("/Routine[@Id='{0}']/SortDirection", Routine)).InnerText = If(DataGridView.SortOrder = SortOrder.Descending, 1, 0)
            Layout.Save(XmlDirectory & "\" & Routine.ToString & ".xml")
        End If
    End Sub
    Public Shared Sub CreateOrUpdateFiles()
        Dim LayoutDocument As New XmlDocument
        Dim OldVersion As Integer
        Dim NewVersion As Integer
        If Not Directory.Exists(XmlDirectory) Then
            Directory.CreateDirectory(XmlDirectory)
        End If
        For Each r In [Enum].GetValues(GetType(Routine))
            If Not String.IsNullOrEmpty(My.Resources.ResourceManager.GetString(r.ToString & "Grid")) Then
                If Not File.Exists(XmlDirectory & "\" & r.ToString & ".xml") Then
                    File.WriteAllText(XmlDirectory & "\" & r.ToString & ".xml", My.Resources.ResourceManager.GetString(r.ToString & "Grid"))
                Else
                    LayoutDocument.Load(XmlDirectory & "\" & r.ToString & ".xml")
                    If LayoutDocument.SelectSingleNode("/Routine").Attributes("Version") Is Nothing Then
                        File.WriteAllText(XmlDirectory & "\" & r.ToString & ".xml", My.Resources.ResourceManager.GetString(r.ToString & "Grid"))
                    Else
                        OldVersion = LayoutDocument.SelectSingleNode("/Routine").Attributes("Version").Value
                        LayoutDocument.LoadXml(My.Resources.ResourceManager.GetString(r.ToString & "Grid"))
                        NewVersion = LayoutDocument.SelectSingleNode("/Routine").Attributes("Version").Value
                        If OldVersion < NewVersion Then
                            File.Delete(XmlDirectory & "\" & r.ToString & ".xml")
                            File.WriteAllText(XmlDirectory & "\" & r.ToString & ".xml", My.Resources.ResourceManager.GetString(r.ToString & "Grid"))
                        End If
                    End If
                End If
            End If
        Next r
    End Sub
End Class