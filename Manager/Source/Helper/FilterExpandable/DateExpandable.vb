Imports System.ComponentModel
Public Class DateExpandable
    Private _InitialDate As String
    Private _FinalDate As String
    <DisplayName("De")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    Public Property InitialDate As Date
        Get
            Return _InitialDate
        End Get
        Set(value As Date)
            If IsDate(value) Then
                _InitialDate = value.ToString("dd/MM/yyyy")
            Else
                _InitialDate = Nothing
            End If
        End Set
    End Property
    <DisplayName("Até")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    Public Property FinalDate As Date
        Get
            Return _FinalDate
        End Get
        Set(value As Date)
            If IsDate(value) Then
                _FinalDate = value.ToString("dd/MM/yyyy")
            Else
                _FinalDate = Nothing
            End If
        End Set
    End Property
    Public Overrides Function ToString() As String
        If InitialDate <> Nothing And FinalDate = Nothing Then
            Return String.Format("A partir de {0}", InitialDate.ToString("dd/MM/yyyy"))
        ElseIf InitialDate <> Nothing And FinalDate <> Nothing Then
            Return String.Format("De {0} a {1}", InitialDate.ToString("dd/MM/yyyy"), FinalDate.ToString("dd/MM/yyyy"))
        ElseIf InitialDate = Nothing And FinalDate <> Nothing Then
            Return String.Format("Até {0}", FinalDate.ToString("dd/MM/yyyy"))
        End If
        Return Nothing
    End Function
    Public Sub New()
        InitialDate = Nothing
        FinalDate = Nothing
    End Sub
End Class
