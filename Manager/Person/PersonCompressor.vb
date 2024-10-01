Imports System.Reflection
Imports ControlLibrary
''' <summary>
''' Representa um compressor de uma pessoa.
''' </summary>
Public Class PersonCompressor
    Public IsSaved As Boolean
    Private _Order As Long
    Private _ID As Long
    Private _Creation As Date = Today
    Public ReadOnly Property Order As Long
        Get
            Return _Order
        End Get
    End Property
    Public ReadOnly Property ID As Long
        Get
            Return _ID
        End Get
    End Property
    Public ReadOnly Property Creation As Date
        Get
            Return _Creation
        End Get
    End Property
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Compressor As New Compressor
    Public Property SerialNumber As String
    Public Property Patrimony As String
    Public Property Sector As String
    Public Property UnitCapacity As Integer = 20000
    Public Property PartsWorkedHour As New OrdenedList(Of PersonCompressorPart)
    Public Property PartsElapsedDay As New OrdenedList(Of PersonCompressorPart)
    Public Property Note As String
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
    Public Function Clone() As PersonCompressor
        Dim PersonCompressorPartWorkedHourClone As PersonCompressorPart
        Dim PersonCompressorPartElapsedDayClone As PersonCompressorPart
        Dim PersonCompressorClone As New PersonCompressor
        PersonCompressorClone.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorClone, ID)
        PersonCompressorClone.GetType.GetField("_Creation", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorClone, Creation)
        PersonCompressorClone.GetType.GetField("_Order", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorClone, Order)
        PersonCompressorClone.Compressor = New Compressor().Load(Compressor.ID, False)
        PersonCompressorClone.Status = Status
        PersonCompressorClone.Sector = Sector
        PersonCompressorClone.UnitCapacity = UnitCapacity
        PersonCompressorClone.SerialNumber = SerialNumber
        PersonCompressorClone.Patrimony = Patrimony
        PersonCompressorClone.IsSaved = IsSaved
        For Each PartWorkedHour In Me.PartsWorkedHour
            PersonCompressorPartWorkedHourClone = New PersonCompressorPart(CompressorPartType.WorkedHour)
            PersonCompressorPartWorkedHourClone.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorPartWorkedHourClone, PartWorkedHour.ID)
            PersonCompressorPartWorkedHourClone.GetType.GetField("_Creation", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorPartWorkedHourClone, PartWorkedHour.Creation)
            PersonCompressorPartWorkedHourClone.GetType.GetField("_Order", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorPartWorkedHourClone, PartWorkedHour.Order)
            PersonCompressorPartWorkedHourClone.PartBind = PartWorkedHour.PartBind
            PersonCompressorPartWorkedHourClone.Status = PartWorkedHour.Status
            PersonCompressorPartWorkedHourClone.ItemName = PartWorkedHour.ItemName
            PersonCompressorPartWorkedHourClone.Product = New Lazy(Of Product)(Function() New Product().Load(PartWorkedHour.Product.Value.ID, False))
            PersonCompressorPartWorkedHourClone.Quantity = PartWorkedHour.Quantity
            PersonCompressorPartWorkedHourClone.Capacity = PartWorkedHour.Capacity
            PersonCompressorPartWorkedHourClone.IsSaved = PartWorkedHour.IsSaved
            PersonCompressorClone.PartsWorkedHour.Add(PersonCompressorPartWorkedHourClone)
        Next PartWorkedHour
        For Each PartElapsedDay In Me.PartsElapsedDay
            PersonCompressorPartElapsedDayClone = New PersonCompressorPart(CompressorPartType.ElapsedDay)
            PersonCompressorPartElapsedDayClone.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorPartElapsedDayClone, PartElapsedDay.ID)
            PersonCompressorPartElapsedDayClone.GetType.GetField("_Creation", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorPartElapsedDayClone, PartElapsedDay.Creation)
            PersonCompressorPartElapsedDayClone.GetType.GetField("_Order", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(PersonCompressorPartElapsedDayClone, PartElapsedDay.Order)
            PersonCompressorPartElapsedDayClone.PartBind = PartElapsedDay.PartBind
            PersonCompressorPartElapsedDayClone.Status = PartElapsedDay.Status
            PersonCompressorPartElapsedDayClone.ItemName = PartElapsedDay.ItemName
            PersonCompressorPartElapsedDayClone.Product = New Lazy(Of Product)(Function() New Product().Load(PartElapsedDay.Product.Value.ID, False))
            PersonCompressorPartElapsedDayClone.Quantity = PartElapsedDay.Quantity
            PersonCompressorPartElapsedDayClone.Capacity = PartElapsedDay.Capacity
            PersonCompressorPartElapsedDayClone.IsSaved = PartElapsedDay.IsSaved
            PersonCompressorClone.PartsElapsedDay.Add(PersonCompressorPartElapsedDayClone)
        Next PartElapsedDay
        Return PersonCompressorClone
    End Function

    Public Overrides Function ToString() As String
        Return Compressor.Name & If(String.IsNullOrEmpty(SerialNumber), Nothing, " NS: " & SerialNumber) & If(String.IsNullOrEmpty(Patrimony), Nothing, " PAT: " & Patrimony) & If(String.IsNullOrEmpty(Sector), Nothing, " - " & Sector)
    End Function
End Class
