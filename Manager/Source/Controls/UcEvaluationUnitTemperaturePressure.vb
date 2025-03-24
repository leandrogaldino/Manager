Public Class UcEvaluationUnitTemperaturePressure
    Public Event ValueChanged As EventHandler
    Private _ManualChanging As Boolean

    Public Property Unit As String
        Get
            Return TxtUnit.Text
        End Get
        Set(value As String)
            _ManualChanging = True
            If TxtUnit.Text <> value Then
                TxtUnit.Text = value
                OnValueChanged(TxtUnit)
            End If
            _ManualChanging = False
        End Set
    End Property
    Public Property Pressure As Decimal
        Get
            Return DbxPressure.DecimalValue
        End Get
        Set(value As Decimal)
            _ManualChanging = True
            If DbxPressure.DecimalValue <> value Then
                DbxPressure.Text = value
                OnValueChanged(DbxPressure)
            End If
            _ManualChanging = False
        End Set
    End Property
    Public Property Temperature As Integer
        Get
            Return Convert.ToInt32(DbxTemperature.DecimalValue)
        End Get
        Set(value As Integer)
            _ManualChanging = True
            If Convert.ToInt32(DbxTemperature.DecimalValue) <> value Then
                DbxTemperature.Text = value
                OnValueChanged(DbxTemperature)
            End If
            _ManualChanging = False
        End Set
    End Property
    Private Sub TxtUnit_DbxTemperature_DbxPressure_TextChanged(sender As Object, e As EventArgs) Handles TxtUnit.TextChanged, DbxTemperature.TextChanged, DbxPressure.TextChanged
        If _ManualChanging Then Return
        OnValueChanged(sender)
    End Sub
    Private Sub OnValueChanged(s)
        RaiseEvent ValueChanged(s, EventArgs.Empty)
    End Sub

End Class
