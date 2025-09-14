Imports ChinhDo.Transactions
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class EmailModel
    Inherits ParentModel
    Public Property Name As String
    Public Property Subject As String
    Public Property Body As String
    Public Property Signature As New EmailSignature

    Private Function GetHtmlString() As String
        Dim HtmlString As String
        Dim HtmlBuilder As New StringBuilder
        HtmlBuilder.AppendLine("<!DOCTYPE html>")
        HtmlBuilder.AppendLine("<html lang='pt-br'>")
        HtmlBuilder.AppendLine("<head>")
        HtmlBuilder.AppendLine("<meta charset='UTF-8'>")
        HtmlBuilder.AppendLine("<meta http-equiv='X-UA-Compatible' content='IE=edge'>")
        HtmlBuilder.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>")
        HtmlBuilder.AppendLine("<title>Corpo do E-Mail</title>")
        HtmlBuilder.AppendLine("</head>")
        HtmlBuilder.AppendLine("<body>")
        If Not String.IsNullOrEmpty(Body) Then HtmlBuilder.AppendFormat("<div>{0}</div>", RtfPipe.Rtf.ToHtml(Body))
        HtmlBuilder.AppendLine("</body>")
        HtmlBuilder.AppendLine("</html>")
        HtmlString = HtmlBuilder.ToString
        HtmlString = HtmlString.Replace("#sdn#", If(Now.Hour >= 1 And Now.Hour <= 12, "Bom dia", If(Now.Hour > 12 And Now.Hour <= 18, "Boa tarde", "Boa noite")))
        HtmlString = HtmlString.Replace("#sdl#", If(Now.Hour >= 1 And Now.Hour <= 12, "bom dia", If(Now.Hour > 12 And Now.Hour <= 18, "boa tarde", "boa noite")))
        HtmlString = HtmlString.Replace("#sdu#", If(Now.Hour >= 1 And Now.Hour <= 12, "BOM DIA", If(Now.Hour > 12 And Now.Hour <= 18, "BOA TARDE", "BOA NOITE")))
        HtmlString &= Signature.SignatureHtml
        Return HtmlString
    End Function
    Public Function CreateHtmlFile() As String
        Dim TempHtmlFile As String
        Dim TempDirectory As String
        Dim Manager As TxFileManager
        Dim FullHtmlContent As String
        TempDirectory = Path.Combine(ApplicationPaths.ManagerTempDirectory, Util.GetFilename())
        TempHtmlFile = Path.Combine(TempDirectory, Util.GetFilename(".html"))
        Manager = New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        If Not String.IsNullOrEmpty(Signature.Directory.CurrentDirectory) Then
            If Manager.DirectoryExists(Signature.Directory.CurrentDirectory) Then
                Manager.CopyDirectory(Signature.Directory.CurrentDirectory, Path.Combine(ApplicationPaths.ManagerTempDirectory, TempDirectory))
            End If
        End If
        FullHtmlContent = GetHtmlString()
        If Not Manager.DirectoryExists(TempDirectory) Then
            Manager.CreateDirectory(TempDirectory)
        End If
        Manager.WriteAllText(TempHtmlFile, FullHtmlContent)
        Return TempHtmlFile
    End Function
    Public Sub New()
        SetRoutine(Routine.EmailModel)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Name = Nothing
        Subject = Nothing
        Body = Nothing
        Signature = New EmailSignature()
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As EmailModel
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.EmailModelSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        SetIsSaved(True)
                        Name = TableResult.Rows(0).Item("name").ToString
                        Subject = TableResult.Rows(0).Item("subject").ToString
                        Body = TableResult.Rows(0).Item("body").ToString
                        Signature = New EmailSignature().Load(TableResult.Rows(0).Item("signatureid"), False)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
    End Sub
    Public Sub Delete()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Using CmdRequest As New MySqlCommand(My.Resources.EmailModelDelete, Con, Tra)
                    CmdRequest.Parameters.AddWithValue("@id", ID)
                    CmdRequest.ExecuteNonQuery()
                End Using
                Tra.Commit()
            End Using
        End Using
            Clear()
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EmailModelInsert, Con)
                Cmd.Parameters.AddWithValue("@ofuserid", Locator.GetInstance(Of Session).User.ID)
                Cmd.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                Cmd.Parameters.AddWithValue("@name", Name)
                Cmd.Parameters.AddWithValue("@subject", If(String.IsNullOrEmpty(Subject), DBNull.Value, Subject))
                Cmd.Parameters.AddWithValue("@body", If(String.IsNullOrEmpty(Body), DBNull.Value, Body))
                Cmd.Parameters.AddWithValue("@signatureid", If(Signature.ID = 0, DBNull.Value, Signature.ID))
                Cmd.Parameters.AddWithValue("@userid", User.ID)
                Cmd.ExecuteNonQuery()
                SetID(Cmd.LastInsertedId)
            End Using
        End Using
    End Sub
    Private Sub Update()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EmailModelUpdate, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@name", Name)
                Cmd.Parameters.AddWithValue("@subject", If(String.IsNullOrEmpty(Subject), DBNull.Value, Subject))
                Cmd.Parameters.AddWithValue("@body", If(String.IsNullOrEmpty(Body), DBNull.Value, Body))
                Cmd.Parameters.AddWithValue("@signatureid", If(Signature.ID = 0, DBNull.Value, Signature.ID))
                Cmd.Parameters.AddWithValue("@userid", User.ID)
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
