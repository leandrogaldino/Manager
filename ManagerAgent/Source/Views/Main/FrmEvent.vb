Imports ControlLibrary
Imports Helpers
Public Class FrmEvent
    Private _Event As EventModel
    Public Sub New([Event] As EventModel)
        InitializeComponent()
        _Event = [Event]
    End Sub

    Private Sub FrmEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Sb As New Text.StringBuilder
        Sb.AppendLine($"ID: {_Event.ID}")
        Sb.AppendLine($"Status: {EnumHelper.GetEnumDescription(_Event.Status)}")
        Sb.AppendLine($"Início: {_Event.StartTime:dd/MM/yyyy HH:mm:ss}")
        Sb.AppendLine($"Fim: {_Event.EndTime:dd/MM/yyyy HH:mm:ss}")
        Sb.AppendLine($"Descrição: {_Event.Description}")
        If Not String.IsNullOrEmpty(_Event.ExceptionMessage) Then
            Sb.AppendLine()
            Sb.AppendLine("Mensagem de Erro:")
            Sb.AppendLine(_Event.ExceptionMessage)
        End If
        If _Event.LogMessages IsNot Nothing AndAlso _Event.LogMessages.Count > 0 Then
            Sb.AppendLine()
            Sb.AppendLine("Mensagens de Log:")
            For Each LogMessage As String In _Event.LogMessages
                Sb.AppendLine(LogMessage)
            Next
        End If
        TxtEvent.ForeColor = If(_Event.Status = TaskStatus.Success, Color.DodgerBlue, Color.DarkRed)
        TxtEvent.Text = Sb.ToString()
    End Sub
End Class