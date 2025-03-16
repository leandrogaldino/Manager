Imports ChinhDo.Transactions
Imports ManagerCore
Imports MySql.Data.MySqlClient
Imports System.IO
Imports ControlLibrary
Public Class EmailSignature
    Inherits ParentModel
    Private _Signature As String
    Public Property Name As String
    Public Property Directory As New DirectoryManager(ApplicationPaths.EmailSignatureDirectory)
    Public ReadOnly Property SignatureHtml As String
        Get
            If String.IsNullOrEmpty(_Signature) Then
                If Not String.IsNullOrEmpty(Directory.CurrentDirectory) Then
                    If File.Exists(Path.Combine(Directory.CurrentDirectory, "sign.html")) Then
                        _Signature = File.ReadAllText(Path.Combine(Directory.CurrentDirectory, "sign.html"))
                    Else
                        _Signature = Nothing
                    End If
                Else
                    _Signature = Nothing
                End If
            End If
            Return _Signature
        End Get
    End Property
    Public Sub New()
        SetRoutine(Routine.EmailSignature)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        _Signature = Nothing
        Name = Nothing
        Directory = New DirectoryManager(ApplicationPaths.EmailSignatureDirectory)
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As EmailSignature
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdEmailSignature As New MySqlCommand(My.Resources.EmailSignatureSelect, Con)
                    CmdEmailSignature.Transaction = Tra
                    CmdEmailSignature.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdEmailSignature)
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
                        If TableResult.Rows(0).Item("directoryname") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("directoryname")) Then
                            Directory.SetCurrentDirectory(Path.Combine(ApplicationPaths.EmailSignatureDirectory, TableResult.Rows(0).Item("directoryname").ToString), True)
                        End If
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
        Dim DirectoryManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEmailSignature As New MySqlCommand(My.Resources.EmailSignatureDelete, Con)
                    CmdEmailSignature.Parameters.AddWithValue("@id", ID)
                    CmdEmailSignature.ExecuteNonQuery()
                    If IO.Directory.Exists(Directory.OriginalDirectory) Then DirectoryManager.DeleteDirectory(Directory.OriginalDirectory)
                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub

    Private Sub Insert()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEmailSignature As New MySqlCommand(My.Resources.EmailSignatureInsert, Con)
                    CmdEmailSignature.Parameters.AddWithValue("@ofuserid", Locator.GetInstance(Of Session).User.ID)
                    CmdEmailSignature.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdEmailSignature.Parameters.AddWithValue("@name", Name)
                    CmdEmailSignature.Parameters.AddWithValue("@directoryname", If(String.IsNullOrEmpty(Directory.CurrentDirectory), DBNull.Value, Path.GetFileName(Directory.CurrentDirectory)))
                    CmdEmailSignature.Parameters.AddWithValue("@userid", User.ID)
                    CmdEmailSignature.ExecuteNonQuery()
                    SetID(CmdEmailSignature.LastInsertedId)
                End Using
            End Using
            Directory.Execute()
            Transaction.Complete()
        End Using
    End Sub

    Private Sub Update()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEmailSignature As New MySqlCommand(My.Resources.EmailSignatureUpdate, Con)
                    CmdEmailSignature.Parameters.AddWithValue("@id", ID)
                    CmdEmailSignature.Parameters.AddWithValue("@name", Name)
                    CmdEmailSignature.Parameters.AddWithValue("@directoryname", If(String.IsNullOrEmpty(Directory.CurrentDirectory), DBNull.Value, Path.GetFileName(Directory.CurrentDirectory)))
                    CmdEmailSignature.Parameters.AddWithValue("@userid", User.ID)
                    CmdEmailSignature.ExecuteNonQuery()
                End Using
            End Using
            Directory.Execute()
            Transaction.Complete()
        End Using
    End Sub

    Public Shared Function GetSignatures(UserID As Long) As List(Of EmailSignature)
        Dim TableResult As New DataTable
        Dim Signature As EmailSignature
        Dim Signatures As New List(Of EmailSignature)
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdEmailSignature As New MySqlCommand(My.Resources.EmailSignaturesSelectByUser, Con)
                CmdEmailSignature.Parameters.AddWithValue("@ofuserid", UserID)
                Using Adapter As New MySqlDataAdapter(CmdEmailSignature)
                    Adapter.Fill(TableResult)
                End Using
            End Using
        End Using
        For Each Row As DataRow In TableResult.Rows
            Signature = New EmailSignature().Load(Row.Item("id"), False)
            Signatures.Add(Signature)
        Next
        Return Signatures
    End Function

    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
