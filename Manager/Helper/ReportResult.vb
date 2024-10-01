Public Class ReportResult
    Public Property FilePath As String
    Public Property ReportName As String
    Public Property Attachments As New List(Of ReportAttachment)
    Public Class ReportAttachment
        Public Sub New(AttachmentPath As String, AttachmentAlias As String)
            Me.AttachmentPath = AttachmentPath
            Me.AttachmentAlias = AttachmentAlias
        End Sub
        Public Property AttachmentPath As String
        Public Property AttachmentAlias As String
    End Class
End Class
