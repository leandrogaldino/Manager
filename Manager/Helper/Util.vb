Public Class Util
    Public Shared Function GetFilename(Optional Extension As String = Nothing) As String
        Dim Filename As New Text.StringBuilder
        Filename.Append(Now.ToString("ddMMyyyyHHmmss"))
        Filename.Append(Guid.NewGuid.ToString("N").ToUpper)
        Filename.Append(IO.Path.GetRandomFileName().Replace(".", Nothing).ToUpper)
        If Not String.IsNullOrEmpty(Extension) Or String.IsNullOrWhiteSpace(Extension) Then
            Filename.Append(Extension)
        End If
        Return Filename.ToString
    End Function
End Class
