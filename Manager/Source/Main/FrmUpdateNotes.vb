Imports System.IO
Imports System.Text
Public Class FrmUpdateNotes
    Private _Updates As New List(Of List(Of String))
    Private Sub FrmUpdateInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FilePath As String = Path.Combine(Application.StartupPath, "Docs/.UpdateNotes")
        Dim Update As New List(Of String)
        Dim Line As String
        If File.Exists(FilePath) Then
            Using Reader As New StreamReader(FilePath, Encoding.UTF8)
                While Not Reader.EndOfStream
                    Line = Reader.ReadLine
                    If Line.StartsWith("#") Then
                        If Update.Count > 0 Then _Updates.Add(Update)
                        Update = New List(Of String)
                    End If
                    Update.Add(Line)
                End While
                If Update.Count > 0 Then _Updates.Add(Update)
            End Using
        End If
        For Each u In _Updates
            u.ForEach(Sub(x)
                          If x.StartsWith("#") Then
                              TvVersions.Nodes.Add(x.Replace("#", Nothing).Trim.PadLeft(5, " ").PadRight(8, " "))
                          End If
                      End Sub)
        Next u
    End Sub

    Private Sub TvVersions_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TvVersions.AfterSelect
        Dim SelectedNode As String = e.Node.Text.Trim
        Dim SelectedUpdate As List(Of String) = _Updates.Single(Function(x) x.First.Replace("#", Nothing).Trim = SelectedNode)
        TxtUpdates.Text = Join(SelectedUpdate.Skip(1).ToArray, vbNewLine & vbNewLine)
        LblTitle.Text = $"Notas da Versão {SelectedNode}"
    End Sub
End Class