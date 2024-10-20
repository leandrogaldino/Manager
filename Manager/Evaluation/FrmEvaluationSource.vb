Public Class FrmEvaluationSource
    Public Property ResultEvaluation As Evaluation
    Public Sub New(Imported As Evaluation, Calculated As Evaluation)
        InitializeComponent()
        Dim Tile As UcEvaluationSourceTile
        Tile = New UcEvaluationSourceTile("Peça", "Técnico", "Sistema", True)
        FlpContainer.Controls.Add(Tile)
        ResultEvaluation = Imported
        For Each p In Imported.PartsWorkedHour.Where(Function(x) x.Part.PartBind)
            Tile = New UcEvaluationSourceTile(p.Part.ToString, p.CurrentCapacity, Calculated.PartsWorkedHour.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity)
            Tile.Tag = p
            AddHandler Tile.SelectionChanged, AddressOf Control_Click
            FlpContainer.Controls.Add(Tile)
        Next p
        For Each p In Imported.PartsElapsedDay.Where(Function(x) x.Part.PartBind)
            Tile = New UcEvaluationSourceTile(p.Part.ToString, p.CurrentCapacity, Calculated.PartsElapsedDay.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity)
            Tile.Tag = p
            AddHandler Tile.SelectionChanged, AddressOf Control_Click
            FlpContainer.Controls.Add(Tile)
        Next p
    End Sub

    Private Sub Control_Click(sender As Object, e As EventArgs)
        Dim AllSelected As Boolean = True
        For Each c As UcEvaluationSourceTile In FlpContainer.Controls
            If Not c.IsHeader Then
                If String.IsNullOrEmpty(c.SelectedValue) Then
                    AllSelected = False
                End If
            End If
        Next c
        BtnAccept.Enabled = AllSelected
    End Sub

    Private Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click


        For i = 0 To ResultEvaluation.PartsWorkedHour.Count - 1

            Dim Tile As UcEvaluationSourceTile = FlpContainer.Controls.Cast(Of UcEvaluationSourceTile).First(Function(x) CType(x.Tag, EvaluationPart).Part.ID = ResultEvaluation.PartsWorkedHour(i).Part.ID)
            ResultEvaluation.PartsWorkedHour(i).CurrentCapacity = Tile.SelectedValue

        Next i






        DialogResult = DialogResult.OK
    End Sub
End Class