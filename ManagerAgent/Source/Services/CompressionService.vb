Imports ControlLibrary
Imports ICSharpCode
Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Imports System.IO.Compression
Imports System.Threading

Public Class CompressionService
    Implements ICompression


    Public Async Function Decompress(Source As String, Destination As String, Password As String, Progress As IProgress(Of Integer)) As Task Implements ICompression.Decompress
        Try

            ' Variável para armazenar o tamanho total dos arquivos descomprimidos
            Dim TotalSize As Long = 0

            ' Primeiro passo: calcular o tamanho real dos arquivos
            Using ZipStream As New ZipInputStream(File.OpenRead(Source))
                ZipStream.Password = Password

                ' Percorrer todas as entradas para somar o tamanho total
                Dim Entry As ZipEntry = ZipStream.GetNextEntry()
                While Entry IsNot Nothing
                    If Not Entry.IsDirectory Then
                        TotalSize += Entry.Size ' Tamanho do arquivo descomprimido
                    End If
                    Entry = ZipStream.GetNextEntry()
                End While
            End Using



            Using ZipStream As New ZipInputStream(File.OpenRead(Source))
                ZipStream.Password = Password

                Dim ProcessedSize As Long = 0





                Dim Entry As ZipEntry = ZipStream.GetNextEntry()




                While Entry IsNot Nothing
                    ' Verificar se a entrada é um diretório
                    If Not Entry.IsDirectory Then
                        ' Caminho completo para o arquivo a ser extraído
                        Dim fullPath As String = Path.Combine(Destination, Entry.Name)
                        Dim directoryPath As String = Path.GetDirectoryName(fullPath)

                        ' Criar o diretório se não existir
                        If Not Directory.Exists(directoryPath) Then
                            Directory.CreateDirectory(directoryPath)
                        End If



                        ' Extrair o arquivo
                        Using FsOutput As FileStream = File.Create(fullPath)
                            Dim Buffer(4096) As Byte
                            Dim BytesRead As Integer
                            Do
                                BytesRead = Await ZipStream.ReadAsync(Buffer, 0, Buffer.Length, CancellationToken.None)
                                If BytesRead > 0 Then
                                    Await FsOutput.WriteAsync(Buffer, 0, BytesRead, CancellationToken.None)
                                    ProcessedSize += BytesRead

                                    ' Atualizar o progresso
                                    Dim percentProgress As Integer = CInt((ProcessedSize / TotalSize) * 100)
                                    Progress.Report(percentProgress)
                                End If
                            Loop While BytesRead > 0
                        End Using
                    End If

                    ' Obter a próxima entrada no arquivo ZIP
                    Entry = ZipStream.GetNextEntry()
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Erro ao descompactar os arquivos.", ex)
        End Try
    End Function
    Public Async Function Compress(Source As String, Destination As String, Password As String, Progress As IProgress(Of Integer)) As Task Implements ICompression.Compress
        Try
            ' Criar o arquivo ZIP de saída
            Using ZipStream As New ZipOutputStream(File.Create(Destination))



                ' Definir o nível de compressão (0-9), onde 9 é o maior
                ZipStream.SetLevel(0)

                ' Definir a senha
                ZipStream.Password = Password


                ' Obter todos os arquivos no diretório
                Dim Files = Directory.GetFiles(Source, "*.*", SearchOption.AllDirectories)
                Dim TotalSize As Long = Files.Sum(Function(file) New FileInfo(file).Length) ' Tamanho total dos arquivos
                Dim ProcessedSize As Long = 0

                ' Adicionar cada arquivo ao ZIP
                For Each FilePath In Files
                    Dim EntryName As String = GetRelativePath(Source, FilePath)
                    Dim Entry As New ZipEntry(EntryName) With {
                        .DateTime = Date.Now
                    }

                    Await ZipStream.PutNextEntryAsync(Entry, CancellationToken.None)

                    ' Ler e escrever o arquivo no stream ZIP
                    Using FsInput As FileStream = File.OpenRead(FilePath)
                        Dim Buffer(4096) As Byte
                        Dim BytesRead As Integer
                        Do
                            BytesRead = Await FsInput.ReadAsync(Buffer, 0, Buffer.Length, CancellationToken.None)
                            If BytesRead > 0 Then
                                Await ZipStream.WriteAsync(Buffer, 0, BytesRead, CancellationToken.None)
                                ProcessedSize += BytesRead
                                Dim percentProgress As Integer = CInt((ProcessedSize / TotalSize) * 100)
                                Progress.Report(percentProgress)
                            End If
                        Loop While BytesRead > 0
                    End Using

                    ' Fechar a entrada ZIP
                    Await ZipStream.CloseEntryAsync(CancellationToken.None)
                Next FilePath
            End Using
        Catch ex As Exception
            Throw New Exception("Erro ao compactar os arquivos.", ex)
        End Try
    End Function

    Private Function GetRelativePath(basePath As String, fullPath As String) As String
        Dim baseUri As New Uri(basePath)
        Dim fullUri As New Uri(fullPath)
        Dim relativeUri As Uri = baseUri.MakeRelativeUri(fullUri)
        Return Uri.UnescapeDataString(relativeUri.ToString().Replace("/", Path.DirectorySeparatorChar))
    End Function





    Public Async Function IsZipFile(FilePath As String) As Task(Of Boolean) Implements ICompression.IsZipFile
        Try
            ' Verifica se o arquivo existe
            If Not File.Exists(FilePath) Then
                Return False
            End If

            ' Abrir o arquivo para leitura
            Using fs As FileStream = File.OpenRead(FilePath)
                If fs.Length < 4 Then
                    Return False ' Arquivo é muito pequeno para ser um ZIP
                End If

                ' Ler os primeiros 4 bytes (assinatura do ZIP)
                Dim buffer(3) As Byte
                Await fs.ReadAsync(buffer, 0, 4)

                ' Verificar se os 4 bytes correspondem à assinatura do ZIP (50 4B 03 04)
                Return buffer(0) = &H50 AndAlso buffer(1) = &H4B AndAlso buffer(2) = &H3 AndAlso buffer(3) = &H4
            End Using
        Catch ex As Exception
            ' Se ocorrer alguma exceção, o arquivo não é um ZIP válido
            Return False
        End Try
    End Function

    Public Async Function IsBackupFile(FilePath As String) As Task(Of Boolean) Implements ICompression.IsBackupFile
        Return Await Task.Run(Function()
                                  Try
                                      Using ZipStream As New ZipInputStream(File.OpenRead(FilePath))
                                          ZipStream.Password = Locator.GetInstance(Of SessionModel).ZipPassword
                                          ' Tentar ler a primeira entrada para verificar a senha
                                          Dim Entry As ZipEntry = ZipStream.GetNextEntry()

                                          If Entry IsNot Nothing Then
                                              ' Se conseguir ler a primeira entrada, a senha está correta
                                              Return True
                                          End If
                                      End Using
                                  Catch ex As ZipException
                                      ' Se houver exceção, a senha provavelmente está incorreta
                                      Return False
                                  End Try
                                  Return False
                              End Function)
    End Function


End Class
