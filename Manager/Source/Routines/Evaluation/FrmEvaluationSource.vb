Public Class FrmEvaluationSource

    Public Property ResultEvaluation As Evaluation
    Public Sub New(EvaluationData As Dictionary(Of String, Object), Signature As String, Photos As List(Of String))
        InitializeComponent()
        Dim HeaderTile As New UcEvaluationSourceHeader()

        Dim PartTile As UcEvaluationSourcePart
        PartTile = New UcEvaluationSourcePart("Peça", "Técnico", "Sistema")
        FlpContainer.Controls.Add(HeaderTile)



        Dim ImportedEvaluation As Evaluation = Nothing
        Dim CalculatedEvaluation As Evaluation = Nothing



        ImportedEvaluation = Evaluation.FromCloud(EvaluationData, Signature, Photos)
        CalculatedEvaluation = Evaluation.FromCloud(EvaluationData, Signature, Photos)
        CalculatedEvaluation.Calculate()

        ResultEvaluation = CalculatedEvaluation
        For Each p In CalculatedEvaluation.PartsWorkedHour.Where(Function(x) x.Part.SellableBind)
            PartTile = New UcEvaluationSourcePart(p.Part.ToString, ImportedEvaluation.PartsWorkedHour.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity, p.CurrentCapacity)
            PartTile.Tag = p
            AddHandler PartTile.ValidateRequired, AddressOf Control_Click
            FlpContainer.Controls.Add(PartTile)
        Next p
        For Each p In CalculatedEvaluation.PartsElapsedDay.Where(Function(x) x.Part.SellableBind)
            PartTile = New UcEvaluationSourcePart(p.Part.ToString, ImportedEvaluation.PartsElapsedDay.First(Function(x) x.Part.ID = p.Part.ID).CurrentCapacity, p.CurrentCapacity)
            PartTile.Tag = p
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

        For Each Part As EvaluationControlledSellable In ResultEvaluation.PartsWorkedHour.Where(Function(x) x.Part.SellableBind)
            Dim Tile As UcEvaluationSourcePart = FlpContainer.Controls.OfType(Of UcEvaluationSourcePart).First(Function(x) x.Tag.Equals(Part))
            Dim PartOnTile As EvaluationControlledSellable = Tile.Tag
            Part.CurrentCapacity = Tile.SelectedValue
            Part.Sold = Tile.UcSoldLost.IsSold
            Part.Lost = Tile.UcSoldLost.IsLost
        Next Part

        For Each Part As EvaluationControlledSellable In ResultEvaluation.PartsElapsedDay.Where(Function(x) x.Part.SellableBind)
            Dim Tile As UcEvaluationSourcePart = FlpContainer.Controls.OfType(Of UcEvaluationSourcePart).First(Function(x) x.Tag.Equals(Part))
            Dim PartOnTile As EvaluationControlledSellable = Tile.Tag
            Part.CurrentCapacity = Tile.SelectedValue
            Part.Sold = Tile.UcSoldLost.IsSold
            Part.Lost = Tile.UcSoldLost.IsLost
        Next Part

        If ResultEvaluation.PartsWorkedHour.Any(Function(x) x.Sold) Or ResultEvaluation.PartsElapsedDay.Any(Function(x) x.Sold) Then
            ResultEvaluation.CallType = CallType.Contract
        Else
            ResultEvaluation.CallType = CallType.Gathering
        End If

        DialogResult = DialogResult.OK
    End Sub

End Class