Imports ControlLibrary

''' <summary>
''' Representa um compressor de uma pessoa.
''' </summary>
Public Class PersonCompressor
    Inherits ChildModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Controlled As ConfirmationType = ConfirmationType.None
    Public Property Compressor As New Lazy(Of Compressor)
    Public Property CompressorID As Long
    Public Property CompressorName As String
    Public Property SerialNumber As String
    Public Property Patrimony As String
    Public Property Sector As String
    Public Property UnitCapacity As Integer = 20000
    Public Property WorkedHourSellables As New List(Of PersonCompressorSellable)
    Public Property ElapsedDaySellables As New List(Of PersonCompressorSellable)
    Public Property Note As String
    Public Sub New()
        SetRoutine(Routine.PersonCompressor)
    End Sub
    Public Overrides Function ToString() As String
        Return CompressorName & If(String.IsNullOrEmpty(SerialNumber), Nothing, " NS: " & SerialNumber) & If(String.IsNullOrEmpty(Patrimony), Nothing, " PAT: " & Patrimony) & If(String.IsNullOrEmpty(Sector), Nothing, " - " & Sector)
    End Function
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New PersonCompressor With {
            .Controlled = Controlled,
            .CompressorID = CompressorID,
            .CompressorName = CompressorName,
            .Note = Note,
            .Status = Status,
            .Sector = Sector,
            .Patrimony = Patrimony,
            .SerialNumber = SerialNumber,
            .UnitCapacity = UnitCapacity,
            .ElapsedDaySellables = ElapsedDaySellables.Select(Function(x) CType(x.Clone(), PersonCompressorSellable)).ToList(),
            .WorkedHourSellables = WorkedHourSellables.Select(Function(x) CType(x.Clone(), PersonCompressorSellable)).ToList(),
            .Compressor = New Lazy(Of Compressor)(
                Function()
                    If Compressor.IsValueCreated Then
                        Return CType(Compressor.Value.Clone(), Compressor)
                    Else
                        Return New Compressor().Load(CompressorID, False)
                    End If
                End Function
            )
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
