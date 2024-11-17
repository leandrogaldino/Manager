''' <summary>
''' Representa um compressor de uma pessoa.
''' </summary>
Public Class PersonCompressor
    Inherits ChildModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Compressor As New Compressor
    Public Property SerialNumber As String
    Public Property Patrimony As String
    Public Property Sector As String
    Public Property UnitCapacity As Integer = 20000
    Public Property PartsWorkedHour As New List(Of PersonCompressorPart)
    Public Property PartsElapsedDay As New List(Of PersonCompressorPart)
    Public Property Note As String
    Public Sub New()
        SetRoutine(Routine.PersonCompressor)
    End Sub
    Public Overrides Function ToString() As String
        Return Compressor.Name & If(String.IsNullOrEmpty(SerialNumber), Nothing, " NS: " & SerialNumber) & If(String.IsNullOrEmpty(Patrimony), Nothing, " PAT: " & Patrimony) & If(String.IsNullOrEmpty(Sector), Nothing, " - " & Sector)
    End Function
End Class
