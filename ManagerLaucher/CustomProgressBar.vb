Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class CustomProgressBar
    Inherits UserControl
    Private _Minimum As Integer = 0
    Private _Maximum As Integer = 100
    Private _Value As Integer = 0
    Private _ProgressTopColor As Color = Color.ForestGreen
    Private _ProgressBottomColor As Color = Color.ForestGreen

    Public Sub New()
        Size = New Size(150, 24)
        BackColor = Color.WhiteSmoke
    End Sub

    <Browsable(True)>
    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            Invalidate()
        End Set
    End Property
    Public Property Minimum As Integer
        Get
            Return _Minimum
        End Get
        Set(value As Integer)

            If value < 0 Then
                value = 0
            End If
            If value > _Maximum Then
                _Maximum = value
            End If
            _Minimum = value
            If _Value < _Minimum Then
                _Value = _Minimum
            End If
            Invalidate()
        End Set
    End Property
    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(value As Integer)
            If value < _Minimum Then
                _Minimum = value
            End If
            _Maximum = value

            If _Value > _Maximum Then
                _Value = _Maximum
            End If
            Invalidate()
        End Set
    End Property
    Public Property ProgressTopColor As Color
        Get
            Return _ProgressTopColor
        End Get
        Set(value As Color)
            _ProgressTopColor = value
            Invalidate()
        End Set
    End Property
    Public Property ProgressBottomColor As Color
        Get
            Return _ProgressBottomColor
        End Get
        Set(value As Color)
            _ProgressBottomColor = value
            Invalidate()
        End Set
    End Property
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(value As Integer)
            Dim OldValue As Integer = _Value
            If value < _Minimum Then
                _Value = _Minimum
            ElseIf value > _Maximum Then
                _Value = _Maximum
            Else
                _Value = value
            End If
            Dim Percent As Single
            Dim NewValueRect As Rectangle = ClientRectangle
            Dim OldValueRect As Rectangle = ClientRectangle
            Percent = (_Value - _Minimum) / (_Maximum - _Minimum)
            NewValueRect.Width = CInt((NewValueRect.Width) * Percent)
            Percent = (OldValue - _Minimum) / (_Maximum - _Minimum)
            OldValueRect.Width = CInt((OldValueRect.Width) * Percent)
            Dim UpdateRect As Rectangle = New Rectangle()
            If NewValueRect.Width > OldValueRect.Width Then
                UpdateRect.X = OldValueRect.Size.Width
                UpdateRect.Width = NewValueRect.Width - OldValueRect.Width
            Else
                UpdateRect.X = NewValueRect.Size.Width
                UpdateRect.Width = OldValueRect.Width - NewValueRect.Width
            End If
            UpdateRect.Height = Me.Height
            Invalidate(UpdateRect)
        End Set
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim rect As Rectangle = Me.ClientRectangle
        Dim brush As LinearGradientBrush = New LinearGradientBrush(rect, ProgressTopColor, ProgressBottomColor, LinearGradientMode.Vertical)
        Dim percent As Single = (_Value - _Minimum) / (_Maximum - _Minimum)
        rect.Width = CInt((rect.Width * percent))
        g.FillRectangle(brush, rect)
        'Draw3DBorder(g)
        Dim textSize = g.MeasureString(Text, Font)
        Using textBrush = New SolidBrush(ForeColor)
            g.DrawString(Text, Font, textBrush, (Width / 2) - (textSize.Width / 2), (Height / 2) - (textSize.Height / 2))
        End Using
        brush.Dispose()
        g.Dispose()
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        Me.Invalidate()
    End Sub
    Private Sub Draw3DBorder(ByVal g As Graphics)
        Dim PenWidth As Integer = CInt(Pens.White.Width)
        g.DrawLine(Pens.DarkGray, New Point(Me.ClientRectangle.Left, Me.ClientRectangle.Top), New Point(Me.ClientRectangle.Width - PenWidth, Me.ClientRectangle.Top))
        g.DrawLine(Pens.DarkGray, New Point(Me.ClientRectangle.Left, Me.ClientRectangle.Top), New Point(Me.ClientRectangle.Left, Me.ClientRectangle.Height - PenWidth))
        g.DrawLine(Pens.White, New Point(Me.ClientRectangle.Left, Me.ClientRectangle.Height - PenWidth), New Point(Me.ClientRectangle.Width - PenWidth, Me.ClientRectangle.Height - PenWidth))
        g.DrawLine(Pens.White, New Point(Me.ClientRectangle.Width - PenWidth, Me.ClientRectangle.Top), New Point(Me.ClientRectangle.Width - PenWidth, Me.ClientRectangle.Height - PenWidth))
    End Sub
End Class
