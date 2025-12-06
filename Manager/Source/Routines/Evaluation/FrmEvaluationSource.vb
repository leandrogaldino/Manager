Public Class FrmEvaluationSource
    Public Property ResultEvaluation As Evaluation
    Public Sub New(EvaluationData As Dictionary(Of String, Object), Signature As String, Pictures As List(Of String))
        InitializeComponent()
        Dim HeaderTile As New UcEvaluationSourceHeader()
        Dim PartTile As UcEvaluationSourcePart
        PartTile = New UcEvaluationSourcePart("Peça", "Técnico", "Sistema")
        FlpContainer.Controls.Add(HeaderTile)
        Dim ImportedEvaluation As Evaluation = Nothing
        Dim CalculatedEvaluation As Evaluation = Nothing
        ImportedEvaluation = Evaluation.FromCloud(EvaluationData, Signature, Pictures)
        CalculatedEvaluation = Evaluation.FromCloud(EvaluationData, Signature, Pictures)
        CalculatedEvaluation.Calculate()
        ResultEvaluation = CalculatedEvaluation
        For Each p In CalculatedEvaluation.WorkedHourControlledSelables.Where(Function(x) x.PersonCompressorSellable.SellableBind)
            PartTile = New UcEvaluationSourcePart(p.PersonCompressorSellable.ToString, ImportedEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.ID = p.PersonCompressorSellable.ID).CurrentCapacity, p.CurrentCapacity) With {.Tag = p}
            AddHandler PartTile.ValidateRequired, AddressOf Control_Click
            FlpContainer.Controls.Add(PartTile)
        Next p
        For Each p In CalculatedEvaluation.ElapsedDayControlledSellables.Where(Function(x) x.PersonCompressorSellable.SellableBind)
            PartTile = New UcEvaluationSourcePart(p.PersonCompressorSellable.ToString, ImportedEvaluation.ElapsedDayControlledSellables.First(Function(x) x.PersonCompressorSellable.ID = p.PersonCompressorSellable.ID).CurrentCapacity, p.CurrentCapacity) With {.Tag = p}
            AddHandler PartTile.ValidateRequired, AddressOf Control_Click
            FlpContainer.Controls.Add(PartTile)
        Next p
    End Sub
    Private Sub Control_Click(sender As Object, e As EventArgs)
        Dim AllSelected As Boolean = True
        For Each c As UcEvaluationSourcePart In FlpContainer.Controls.OfType(Of UcEvaluationSourcePart)
            If Not c.UcSoldLost.AnyChecked Then AllSelected = False
            If String.IsNullOrEmpty(c.SelectedValue) Then AllSelected = False
        Next c
        BtnAccept.Enabled = AllSelected
    End Sub
    Private Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click
        For Each Part As EvaluationControlledSellable In ResultEvaluation.WorkedHourControlledSelables.Where(Function(x) x.PersonCompressorSellable.SellableBind)
            Dim Tile As UcEvaluationSourcePart = FlpContainer.Controls.OfType(Of UcEvaluationSourcePart).First(Function(x) x.Tag.Equals(Part))
            Dim PartOnTile As EvaluationControlledSellable = Tile.Tag
            Part.CurrentCapacity = Tile.SelectedValue
            Part.Sold = Tile.UcSoldLost.IsSold
            Part.Lost = Tile.UcSoldLost.IsLost
        Next Part
        For Each Part As EvaluationControlledSellable In ResultEvaluation.ElapsedDayControlledSellables.Where(Function(x) x.PersonCompressorSellable.SellableBind)
            Dim Tile As UcEvaluationSourcePart = FlpContainer.Controls.OfType(Of UcEvaluationSourcePart).First(Function(x) x.Tag.Equals(Part))
            Dim PartOnTile As EvaluationControlledSellable = Tile.Tag
            Part.CurrentCapacity = Tile.SelectedValue
            Part.Sold = Tile.UcSoldLost.IsSold
            Part.Lost = Tile.UcSoldLost.IsLost
        Next Part
        If ResultEvaluation.WorkedHourControlledSelables.Any(Function(x) x.Sold) Or ResultEvaluation.ElapsedDayControlledSellables.Any(Function(x) x.Sold) Then
            ResultEvaluation.HasRepair = ConfirmationType.Yes
        Else
            ResultEvaluation.HasRepair = ConfirmationType.No
        End If
        DialogResult = DialogResult.OK
    End Sub
End Class