Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.Utility

Public Class FrmMain
    Private _FilePath As String
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        TxtCryptoKey.Text = My.Settings.CryptoKey
        TsBar.Renderer = New CustomToolstripRender
    End Sub
    Private Sub BtnGenerateKey_Click(sender As Object, e As EventArgs) Handles BtnGenerateKey.Click
        TxtGeneratedKey.Text = GetRandomString(5, 5, "-", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        BtnCopyKey.Visible = True
    End Sub
    Private Sub BtnCopyKey_Click(sender As Object, e As EventArgs) Handles BtnCopyKey.Click
        Clipboard.SetText(TxtGeneratedKey.Text)
        CMessageBox.Show("A chave foi copiada para a área de transferência", CMessageBoxType.Information)
    End Sub

    Private Sub TcTool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcTool.SelectedIndexChanged
        If TcTool.SelectedTab Is TabKey Then
            Size = New Size(405, 160)
            WindowState = FormWindowState.Normal
            FormBorderStyle = FormBorderStyle.FixedSingle
            MaximizeBox = False
        ElseIf TcTool.SelectedTab Is TabCrypto Then
            Size = New Size(700, 500)
            MaximizeBox = True
            FormBorderStyle = FormBorderStyle.Sizable

        End If
    End Sub

    Private Sub BtnOpenFile_Click(sender As Object, e As EventArgs) Handles BtnOpenFile.Click
        OfdFile.FileName = Nothing
        If OfdFile.ShowDialog = DialogResult.OK Then
            Read(OfdFile.FileName)
        End If
    End Sub

    Private Sub BtnSaveContent_Click(sender As Object, e As EventArgs) Handles BtnSaveContent.Click
        SfdFile.FileName = Path.GetFileNameWithoutExtension(_FilePath)
        If SfdFile.ShowDialog = DialogResult.OK Then
            Try
                File.WriteAllText(SfdFile.FileName, Cryptography.Encrypt(TxtFileContent.Text, TxtCryptoKey.Text))
            Catch ex As Exception
                CMessageBox.Show("Erro Ao Salvar", ex.Message, CMessageBoxButtons.OK, MessageBoxIcon.Error, ex)
            End Try
        End If
    End Sub


    Private Sub TxtFileContent_DragEnter(sender As Object, e As DragEventArgs) Handles TxtFileContent.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TxtFileContent_DragDrop(sender As Object, e As DragEventArgs) Handles TxtFileContent.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length > 0 Then
            Read(files(0))
        End If
    End Sub
    Public Sub Read(Path As String)
        _FilePath = Path
        Try
            TxtFileContent.Text = Cryptography.Decrypt(File.ReadAllText(Path), TxtCryptoKey.Text)
        Catch ex As FormatException
            CMessageBox.Show("Erro Ao Ler", "Esse arquivo não é um arquivo criptografado válido.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Catch ex As Security.Cryptography.CryptographicException
            CMessageBox.Show("Erro Ao Ler", "A CryptoKey informada não condiz com a CryptoKey utilizada para criptografar os dados desse arquivo.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Catch ex As Exception
            CMessageBox.Show("Erro Ao Ler", ex.Message, CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
    End Sub

    Private Sub TxtCryptoKey_TextChanged(sender As Object, e As EventArgs) Handles TxtCryptoKey.TextChanged
        My.Settings.CryptoKey = TxtCryptoKey.Text
        My.Settings.Save()
    End Sub
End Class
