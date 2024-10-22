Public Class FrmEvaluationSource
    Public Property ResultEvaluation As Evaluation
    Public Sub New(Imported As Evaluation, Calculated As Evaluation)
        InitializeComponent()
        Dim Header As New UcEvaluationSourceHeader()
        Dim Tile As UcEvaluationSourceItem
        Tile = New UcEvaluationSourceItem("Peça", "Técnico", "Sistema", False, False)
        FlpContainer.Controls.Add(Header)
        ResultEvaluation = Imported
        For Each p In Imported.PartsWorkedHour.Where(Function(x) x.Part.PartBind)
            Tile = New UcEvaluationSourceItem(p.Part.ToString, p.CurrentCapacity, Calculated.PartsWorkedHour.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity, False, False)
            Tile.Tag = p
            AddHandler Tile.SelectionChanged, AddressOf Control_Click
            FlpContainer.Controls.Add(Tile)
        Next p
        For Each p In Imported.PartsElapsedDay.Where(Function(x) x.Part.PartBind)
            Tile = New UcEvaluationSourceItem(p.Part.ToString, p.CurrentCapacity, Calculated.PartsElapsedDay.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity, False, False)
            Tile.Tag = p
            AddHandler Tile.SelectionChanged, AddressOf Control_Click
            FlpContainer.Controls.Add(Tile)
        Next p
    End Sub

    Private Sub Control_Click(sender As Object, e As EventArgs)
        Dim AllSelected As Boolean = True
        For Each c As UcEvaluationSourceItem In FlpContainer.Controls.OfType(Of UcEvaluationSourceItem)
            If String.IsNullOrEmpty(c.SelectedValue) Then
                AllSelected = False
            End If
        Next c
        BtnAccept.Enabled = AllSelected
    End Sub

    Private Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click


        For i = 0 To ResultEvaluation.PartsWorkedHour.Count - 1

            Dim Tile As UcEvaluationSourceItem = FlpContainer.Controls.Cast(Of UcEvaluationSourceItem).First(Function(x) CType(x.Tag, EvaluationPart).Part.ID = ResultEvaluation.PartsWorkedHour(i).Part.ID)
            ResultEvaluation.PartsWorkedHour(i).CurrentCapacity = Tile.SelectedValue

        Next i






        DialogResult = DialogResult.OK
    End Sub
End Class