Imports CoreSuite.Controls

Public Class UcBackupDays
    Public Event ValueChanged(Day As String)
    Private _Container As ControlContainer
    Private _ManualChange As Boolean

    Public Sub New(Container As ControlContainer)
        InitializeComponent()
        _Container = Container
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _Container.CloseDropDown()
    End Sub

    Public Property Monday As Boolean
        Get
            Return CbxMonday.Checked
        End Get
        Set(value As Boolean)
            If value = CbxMonday.Checked Then Return
            If Not _ManualChange Then CbxMonday.Checked = value
            RaiseEvent ValueChanged("Monday")
        End Set
    End Property
    Public Property Tuesday As Boolean
        Get
            Return CbxTuesday.Checked
        End Get
        Set(value As Boolean)
            If value = CbxTuesday.Checked Then Return
            If Not _ManualChange Then CbxTuesday.Checked = value
            RaiseEvent ValueChanged("Tuesday")
        End Set
    End Property
    Public Property Wednesday As Boolean
        Get
            Return CbxWednesday.Checked
        End Get
        Set(value As Boolean)
            If value = CbxWednesday.Checked Then Return
            If Not _ManualChange Then CbxWednesday.Checked = value
            RaiseEvent ValueChanged("Wednesday")
        End Set
    End Property
    Public Property Thursday As Boolean
        Get
            Return CbxThursday.Checked
        End Get
        Set(value As Boolean)
            If value = CbxThursday.Checked Then Return
            If Not _ManualChange Then CbxThursday.Checked = value
            RaiseEvent ValueChanged("Thursday")
        End Set
    End Property
    Public Property Friday As Boolean
        Get
            Return CbxFriday.Checked
        End Get
        Set(value As Boolean)
            If value = CbxFriday.Checked Then Return
            If Not _ManualChange Then CbxFriday.Checked = value
            RaiseEvent ValueChanged("Friday")
        End Set
    End Property
    Public Property Saturday As Boolean
        Get
            Return CbxSaturday.Checked
        End Get
        Set(value As Boolean)
            If value = CbxSaturday.Checked Then Return
            If Not _ManualChange Then CbxSaturday.Checked = value
            RaiseEvent ValueChanged("Saturday")
        End Set
    End Property
    Public Property Sunday As Boolean
        Get
            Return CbxSunday.Checked
        End Get
        Set(value As Boolean)
            If value = CbxSunday.Checked Then Return
            If Not _ManualChange Then CbxSunday.Checked = value
            RaiseEvent ValueChanged("Sunday")
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim Days As New List(Of String)
        If Monday Then Days.Add("Seg")
        If Tuesday Then Days.Add("Ter")
        If Wednesday Then Days.Add("Qua")
        If Thursday Then Days.Add("Qui")
        If Friday Then Days.Add("Sex")
        If Saturday Then Days.Add("Sab")
        If Sunday Then Days.Add("Dom")
        Return If(Days.Count = 0, "Nenhum", String.Join(", ", Days))
    End Function

    Private Sub CbxMonday_CheckedChanged(sender As Object, e As EventArgs) Handles CbxMonday.CheckedChanged
        _ManualChange = True
        CbxMonday.Text = If(CbxMonday.Checked, "Sim", "Não")
        Monday = CbxMonday.Checked
        RaiseEvent ValueChanged("Monday")
        _ManualChange = False
    End Sub
    Private Sub CbxTuesday_CheckedChanged(sender As Object, e As EventArgs) Handles CbxTuesday.CheckedChanged
        _ManualChange = True
        CbxTuesday.Text = If(CbxTuesday.Checked, "Sim", "Não")
        Tuesday = CbxTuesday.Checked
        RaiseEvent ValueChanged("Tuesday")
        _ManualChange = False
    End Sub
    Private Sub CbxWednesday_CheckedChanged(sender As Object, e As EventArgs) Handles CbxWednesday.CheckedChanged
        _ManualChange = True
        CbxWednesday.Text = If(CbxWednesday.Checked, "Sim", "Não")
        Wednesday = CbxWednesday.Checked
        RaiseEvent ValueChanged("Wednesday")
        _ManualChange = False
    End Sub
    Private Sub CbxThursday_CheckedChanged(sender As Object, e As EventArgs) Handles CbxThursday.CheckedChanged
        _ManualChange = True
        CbxThursday.Text = If(CbxThursday.Checked, "Sim", "Não")
        Thursday = CbxThursday.Checked
        RaiseEvent ValueChanged("Thursday")
        _ManualChange = False
    End Sub

    Private Sub CbxFriday_CheckedChanged(sender As Object, e As EventArgs) Handles CbxFriday.CheckedChanged
        _ManualChange = True
        CbxFriday.Text = If(CbxFriday.Checked, "Sim", "Não")
        Friday = CbxFriday.Checked
        RaiseEvent ValueChanged("Friday")
        _ManualChange = False
    End Sub

    Private Sub CbxSaturday_CheckedChanged(sender As Object, e As EventArgs) Handles CbxSaturday.CheckedChanged
        _ManualChange = True
        CbxSaturday.Text = If(CbxSaturday.Checked, "Sim", "Não")
        Saturday = CbxSaturday.Checked
        RaiseEvent ValueChanged("Saturday")
        _ManualChange = False
    End Sub

    Private Sub CbxSunday_CheckedChanged(sender As Object, e As EventArgs) Handles CbxSunday.CheckedChanged
        _ManualChange = True
        CbxSunday.Text = If(CbxSunday.Checked, "Sim", "Não")
        Sunday = CbxSunday.Checked
        RaiseEvent ValueChanged("Sunday")
        _ManualChange = False
    End Sub

End Class