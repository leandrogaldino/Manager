Public Class FrmEvaluationSource
    Public Property ResultEvaluation As Evaluation
    Public Sub New(Imported As Evaluation, Calculated As Evaluation)
        InitializeComponent()
        Dim Header As New UcEvaluationSourceHeader()
        Dim Tile As UcEvaluationSourceItem
        Tile = New UcEvaluationSourceItem("Peça", "Técnico", "Sistema")
        FlpContainer.Controls.Add(Header)
        ResultEvaluation = Imported
        For Each p In Imported.PartsWorkedHour.Where(Function(x) x.Part.PartBind)
            Tile = New UcEvaluationSourceItem(p.Part.ToString, p.CurrentCapacity, Calculated.PartsWorkedHour.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity)
            Tile.Tag = p
            AddHandler Tile.ValidateRequired, AddressOf Control_Click
            FlpContainer.Controls.Add(Tile)
        Next p
        For Each p In Imported.PartsElapsedDay.Where(Function(x) x.Part.PartBind)
            Tile = New UcEvaluationSourceItem(p.Part.ToString, p.CurrentCapacity, Calculated.PartsElapsedDay.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity)
            Tile.Tag = p
            AddHandler Tile.ValidateRequired, AddressOf Control_Click
            FlpContainer.Controls.Add(Tile)
        Next p
    End Sub

    Private Sub Control_Click(sender As Object, e As EventArgs)
        Dim AllSelected As Boolean = True
        For Each c As UcEvaluationSourceItem In FlpContainer.Controls.OfType(Of UcEvaluationSourceItem)
            If Not c.UcSoldLost.AnyChecked Then AllSelected = False
            If String.IsNullOrEmpty(c.SelectedValue) Then AllSelected = False
        Next c
        BtnAccept.Enabled = AllSelected
    End Sub

    Private Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click


        For Each Part As EvaluationPart In ResultEvaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind)
            Dim Tile As UcEvaluationSourceItem = FlpContainer.Controls.OfType(Of UcEvaluationSourceItem).First(Function(x) x.Tag.Equals(Part))
            Dim PartOnTile As EvaluationPart = Tile.Tag
            Part.CurrentCapacity = Tile.SelectedValue
            Part.Sold = Tile.UcSoldLost.IsSold
            Part.Lost = Tile.UcSoldLost.IsLost
        Next Part


        For Each Part As EvaluationPart In ResultEvaluation.PartsElapsedDay.Where(Function(x) x.Part.PartBind)
            Dim Tile As UcEvaluationSourceItem = FlpContainer.Controls.OfType(Of UcEvaluationSourceItem).First(Function(x) x.Tag.Equals(Part))
            Dim PartOnTile As EvaluationPart = Tile.Tag
            Part.CurrentCapacity = Tile.SelectedValue
            Part.Sold = Tile.UcSoldLost.IsSold
            Part.Lost = Tile.UcSoldLost.IsLost
        Next Part

        DialogResult = DialogResult.OK
    End Sub
End Class