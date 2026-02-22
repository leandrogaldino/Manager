Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DataGridViewDecimalColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New DataGridViewDecimalCell())
        Me.ValueType = GetType(Decimal)
        Me.DefaultCellStyle.Format = "N2"
    End Sub

    <Browsable(True)>
    Public Property DecimalPlaces As Integer = 2

    Public Overrides Function Clone() As Object
        Dim col As DataGridViewDecimalColumn = CType(MyBase.Clone(), DataGridViewDecimalColumn)
        col.DecimalPlaces = Me.DecimalPlaces
        Return col
    End Function
End Class

Public Class DataGridViewDecimalCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        Me.Style.Format = "N2"
    End Sub

    Public Overrides ReadOnly Property EditType As Type
        Get
            Return GetType(DataGridViewDecimalEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType As Type
        Get
            Return GetType(Decimal)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue As Object
        Get
            Return 0D
        End Get
    End Property
    Public Overrides Function ParseFormattedValue(
    formattedValue As Object,
    cellStyle As DataGridViewCellStyle,
    formattedValueTypeConverter As TypeConverter,
    valueTypeConverter As TypeConverter) As Object

        If formattedValue Is Nothing OrElse String.IsNullOrWhiteSpace(formattedValue.ToString()) Then
            Return 0D
        End If

        Dim valorDecimal As Decimal

        If Decimal.TryParse(formattedValue.ToString(),
                            Globalization.NumberStyles.Any,
                            Globalization.CultureInfo.CurrentCulture,
                            valorDecimal) Then

            Return valorDecimal
        End If

        Return 0D

    End Function
    Public Overrides Sub InitializeEditingControl(rowIndex As Integer,
                                              initialFormattedValue As Object,
                                              dataGridViewCellStyle As DataGridViewCellStyle)

        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

        If Me.Value Is Nothing OrElse IsDBNull(Me.Value) Then
            Me.Value = 0D
        End If
    End Sub
End Class

Class DataGridViewDecimalEditingControl
    Inherits TextBox
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.TextAlign = HorizontalAlignment.Right
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        Dim sep As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If Not Char.IsDigit(e.KeyChar) AndAlso
           e.KeyChar.ToString() <> sep AndAlso
           e.KeyChar <> ChrW(Keys.Back) Then

            e.Handled = True
        End If

        ' Impede mais de um separador decimal
        If e.KeyChar.ToString() = sep AndAlso Me.Text.Contains(sep) Then
            e.Handled = True
        End If
    End Sub

    Public Property EditingControlFormattedValue As Object _
    Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Text
        End Get

        Set(value As Object)
            If value IsNot Nothing Then
                Me.Text = value.ToString()
            Else
                Me.Text = ""
            End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) _
    As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Dim valorDecimal As Decimal

        If Decimal.TryParse(Me.Text,
                        Globalization.NumberStyles.Any,
                        Globalization.CultureInfo.CurrentCulture,
                        valorDecimal) Then

            Return valorDecimal
        End If

        Return 0D

    End Function

    Public Sub ApplyCellStyleToEditingControl(dataGridViewCellStyle As DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor
    End Sub

    Public Property EditingControlRowIndex As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNum
        End Get
        Set(value As Integer)
            rowIndexNum = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) _
    As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        Select Case keyData And Keys.KeyCode
            Case Keys.Left, Keys.Right, Keys.Home, Keys.End
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        If selectAll Then
            Me.SelectAll()
        End If
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean _
        Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridViewControl
        End Get
        Set(value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueChanged
        End Get
        Set(value As Boolean)
            valueChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingPanelCursor As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        valueChanged = True
        dataGridViewControl.NotifyCurrentCellDirty(True)
        MyBase.OnTextChanged(e)
    End Sub
End Class