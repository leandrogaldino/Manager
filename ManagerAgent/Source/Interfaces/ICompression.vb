Public Interface ICompression
    Function Compress(Source As String, Destination As String, Password As String, Progress As IProgress(Of Integer)) As Task
    Function Decompress(Source As String, Destination As String, Password As String, Progress As IProgress(Of Integer)) As Task
    Function IsZipFile(Source As String) As Task(Of Boolean)
    Function IsBackupFile(Source As String) As Task(Of Boolean)
End Interface
