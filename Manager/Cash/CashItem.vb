Imports System.Reflection
Imports ControlLibrary
''' <summary>
''' Representa um lançamento do caixa.
''' </summary>
Public Class CashItem
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

    Public Property ItemType As CashItemType = CashItemType.Expense
    Public Property ItemCategory As CashItemCategory = CashItemCategory.Food
    Public Property Responsibles As New OrdenedList(Of CashItemResponsible)
    Public Property Description As String
    Public Property DocumentDate As Date = Today
    Public Property DocumentNumber As String
    Public Property Value As Decimal
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
    Public Function Clone() As CashItem
        Dim ResponsibleClone As CashItemResponsible
        Dim CashItemClone As New CashItem
        CashItemClone.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(CashItemClone, ID)
        CashItemClone.GetType.GetField("_Creation", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(CashItemClone, Creation)
        CashItemClone.GetType.GetField("_Order", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(CashItemClone, Order)
        CashItemClone.Description = Description
        CashItemClone.DocumentDate = DocumentDate
        CashItemClone.DocumentNumber = DocumentNumber
        CashItemClone.ItemType = ItemType
        CashItemClone.ItemCategory = ItemCategory
        CashItemClone.Value = Value
        CashItemClone.IsSaved = IsSaved
        For Each Responsible In Me.Responsibles
            ResponsibleClone = New CashItemResponsible
            ResponsibleClone.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(ResponsibleClone, Responsible.ID)
            ResponsibleClone.GetType.GetField("_Creation", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(ResponsibleClone, Responsible.Creation)
            ResponsibleClone.GetType.GetField("_Order", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(ResponsibleClone, Responsible.Order)
            ResponsibleClone.Responsible = New Person().Load(Responsible.Responsible.ID, False)
            ResponsibleClone.IsSaved = Responsible.IsSaved
            CashItemClone.Responsibles.Add(ResponsibleClone)
        Next Responsible
        Return CashItemClone
    End Function
End Class